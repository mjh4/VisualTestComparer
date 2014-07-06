using System;
using MonoMac.AppKit;
using System.Drawing;
using MonoMac.ImageKit;
using MonoMac.Foundation;

namespace VisualTestComparer
{
	public class ImageCarouselView : IKImageBrowserView
	{
		public ImageCarouselView ()
		{
			CellSize = new SizeF (Frame.Height, Frame.Height);
		}

		public override int RowCount {
			get {
				return 1;
			}
		}
	}

	public class ImageCarouselViewDelegate : IKImageBrowserDelegate
	{
		public override void BackgroundWasRightClicked (IKImageBrowserView browser, NSEvent nsevent)
		{

		}
	}

	class ImageCarouselViewDataSource : IKImageBrowserDataSource
	{
		string[] ImageFilePaths {
			get {
				return new [] {
					"/Users/alan/test.png",
					"/Users/alan/test.png",
					"/Users/alan/test.png",
					"/Users/alan/test.png",
					"/Users/alan/test.png",
				};
			}
		}

		public override int ItemCount (IKImageBrowserView aBrowser)
		{
			return ImageFilePaths.Length;
		}

		public override IKImageBrowserItem GetItem (IKImageBrowserView aBrowser, int index)
		{
			return new ImageItem (ImageFilePaths [index]);
		}
	}

	class ImageItem : IKImageBrowserItem
	{
		string ImagePath {
			get; set;
		}
		public override string ImageTitle {
			get {
				return "Subtitle " + ImagePath;
			}
		}
		public override MonoMac.Foundation.NSObject ImageRepresentation {
			get {
				return (NSString) ImagePath;
			}
		}

		public override MonoMac.Foundation.NSString ImageRepresentationType {
			get {
				var handle = MonoMac.ObjCRuntime.Dlfcn.dlopen (MonoMac.Constants.ImageKitLibrary, 0);
				return MonoMac.ObjCRuntime.Dlfcn.GetStringConstant (handle, "IKImageBrowserPathRepresentationType");
			}
		}

		public override string ImageUID {
			get {
				return ImageTitle;
			}
		}

		public ImageItem (string imagePath)
		{
			ImagePath = imagePath;
		}
	}
}

