using System;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Xml.Linq;
using System.Security.Cryptography;
using Tests;
using System.IO;
using Xwt.Drawing;

namespace MonoTouch.Design.Client
{
	[TestFixture]
	public abstract class VisualValidationTestBase : ServerBasedTest
	{
		static readonly SHA1 Hasher = SHA1.Create ();

		string MasterImage (string imageName)
		{
			var mastersRoot = Path.Combine ("..", "..", "tests", "MonoTouch.Designer.Client.Tests", "VisualValidation", "Masters");
			var version = DesignerSession.IosVersion;
			var runtime = DesignerSession.TargetRuntime.HasFlag (DeviceTrait.Phone) ? "OriginalPhone" : "OriginalPad";

			for (int monorVersion = version.Minor; monorVersion >= 0; monorVersion--) {
				var potential = Path.Combine (mastersRoot, string.Format ("{0}.{1}", version.Major, monorVersion), runtime, imageName + ".png");
				if (File.Exists (potential))
					return potential;
			}
			return Path.Combine (mastersRoot, string.Format ("{0}.{1}", version.Major, version.Minor), runtime, imageName + ".png");
		}

		string FailedImage (string imageName, string suffix)
		{
			return Path.Combine ("..", "..", "..", "VisualFailures", string.Format ("{0}-{1}.png", imageName, suffix));
		}

		protected async Task<bool> Validate (XElement element)
		{
			return await Validate (element, "");
		}

		protected async Task<bool> Validate (XElement element, string message, int sceneID = -1)
		{
			var elementBytes = System.Text.Encoding.UTF8.GetBytes (element.ToString ());
			var imageName = BitConverter.ToString (Hasher.ComputeHash (elementBytes)).Replace ("-", "") + (sceneID != -1 ? sceneID.ToString () : string.Empty);
			var imagePath = MasterImage (imageName);

			// Clone the element so we can be 100% sure that our original XElement is not changed when we match the ModelObjects to the XML
			// This is the safest way to ensure our hashing of the input bytes is 100% reliable.
			var model = await Render (XElement.Parse (element.ToString ()));
			var xib = model as Xib;
			var storyboard = model as Storyboard;

			VisualObject vo;
			if (storyboard != null)
				vo = (VisualObject)storyboard.Scenes [Math.Max (0, sceneID)];
			else if (xib != null)
				vo = (VisualObject)xib.Objects [Math.Max (0, sceneID)];
			else
				vo = model as VisualObject;

			if (vo == null)
				return true;

			vo.Frame = new System.Drawing.RectangleF (System.Drawing.PointF.Empty, vo.Frame.Size);

			if (!File.Exists (imagePath)) {
				// Skip anything with no master image and no rendered image
				if (vo.RenderedImage == null)
					return true;

				Directory.CreateDirectory (Path.GetDirectoryName (imagePath));
				File.WriteAllBytes (imagePath, AddBoundingBoxes (vo));
				Assert.Fail (string.Format ("Master image did not exist. A new master image has been generated at {0}. ", imagePath) + message);
			}

			var masterImageBytes = File.ReadAllBytes (imagePath);
			var renderedImageBytes = AddBoundingBoxes (vo);
			if (!Compare (masterImageBytes, renderedImageBytes)) {
				Directory.CreateDirectory (Path.GetDirectoryName (FailedImage ("a", "")));
				File.WriteAllBytes (FailedImage ("master-" + message + "-", imageName), masterImageBytes);
				File.WriteAllBytes (FailedImage ("render-" + message + "-", imageName), renderedImageBytes);
				return false;
			}

			return true;
		}

		protected async Task ValidateAndAssert (XElement element)
		{
			Assert.IsTrue (await Validate (element));
		}

		protected async Task ValidateAndAssert (XElement element, string message, int sceneID = -1)
		{
			Assert.IsTrue (await Validate (element, message, sceneID), message);
		}

		byte[] AddBoundingBoxes (VisualObject model)
		{
			using (var image = Image.FromStream (new MemoryStream (model.RenderedImage))) {
				using (var builder = new ImageBuilder (image.Width, image.Height)) {
					builder.Context.DrawImage (image, Xwt.Point.Zero);

					AddBoundingBoxes (model, builder, Xwt.Point.Zero);

					var outputStream = new MemoryStream ();
					builder.ToBitmap (ImageFormat.ARGB32).Save (outputStream, ImageFileType.Png);
					return outputStream.ToArray ();
				}
			}
		}

		void AddBoundingBoxes (VisualObject model, ImageBuilder builder, Xwt.Point offset)
		{
			if (model is Scene) {
				var scene = (Scene)model;
				RenderBoundingBox (scene.ViewController.StatusBarFrame.ToXwtRectangle (), builder);
				AddBoundingBoxes (scene.ViewController, builder, Xwt.Point.Zero);
				offset = new Xwt.Point (-scene.Frame.X, -scene.Frame.Y);
			} else if (model is ProxiedViewController) {
				var vc = (ProxiedViewController)model;
				if (vc.View != null)
					AddBoundingBoxes (vc.View, builder, offset);
				RenderBoundingBox (vc.TopBarFrame.ToXwtRectangle ().Offset (offset), builder);
				RenderBoundingBox (vc.BottomBarFrame.ToXwtRectangle ().Offset (offset), builder);
			} else if (model is ProxiedView) {
				foreach (var subview in ((ProxiedView)model).Subviews)
					AddBoundingBoxes (subview, builder, offset.Offset (model.Frame.Location.ToXwtPoint ()));
			}
			RenderBoundingBox (model.Frame.ToXwtRectangle ().Offset (offset), builder);
		}

		void RenderBoundingBox (Xwt.Rectangle frame, ImageBuilder builder)
		{
			builder.Context.Save ();
			builder.Context.SetLineWidth (2);
			builder.Context.SetLineDash (0, new [] { 2.0, 2.0 });
			builder.Context.SetColor (Colors.Red);
			builder.Context.Rectangle (frame);
			builder.Context.Stroke ();
			builder.Context.Restore ();

			builder.Context.Save ();
			builder.Context.SetLineWidth (2);
			builder.Context.SetLineDash (0.5, new [] { 0.5, 0.5 });
			builder.Context.SetColor (Colors.Green);
			builder.Context.Rectangle (frame);
			builder.Context.Stroke ();
			builder.Context.Restore ();
		}

		bool Compare (byte[] master, byte[] actual)
		{
			var masterImage = new System.Drawing.Bitmap (new MemoryStream (master));
			var renderImage = new System.Drawing.Bitmap (new MemoryStream (actual));

			int difference = 0;
			for (int width = 0; width < masterImage.Width && difference < 10; width++) {
				for (int height = 0; height < masterImage.Height && difference < 10; height++) {
					if (!masterImage.GetPixel (width, height).Equals (renderImage.GetPixel (width, height)))
						difference++;
				}
			}

			return difference < 10;
		}
	}
}

