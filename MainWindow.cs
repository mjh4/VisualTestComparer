
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace VisualTestComparer
{
	public partial class MainWindow : MonoMac.AppKit.NSWindow
	{
		#region Constructors
		ImageCarouselView ImageCarouselView {
			get; set;
		}

		ImageCarouselViewDataSource ImageCarouselViewDataSource {
			get; set;
		}

		ImageSelectorDataSource ImageSelectorDataSource {
			get; set;
		}

		ImageSelectorDelegate ImageSelectorDelegate {
			get; set;
		}

		ImageSelectorView ImageSelectorView {
			get; set;
		}

		NSTextField XmlViewer {
			get; set;
		}

		// Called when created from unmanaged code
		public MainWindow (IntPtr handle) : base (handle)
		{

		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{

		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			CreateImageSelectorView ();
			CreateImageCarouselView ();
			CreateXmlViewer ();
		}

		void CreateImageSelectorView ()
		{
			var scroller = new NSScrollView (ImageSelector.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
			};

			this.ImageSelectorDelegate = new ImageSelectorDelegate ();
			this.ImageSelectorDataSource = new ImageSelectorDataSource ();
			this.ImageSelectorView = new ImageSelectorView {
				DataSource = ImageSelectorDataSource,
				Delegate = ImageSelectorDelegate,
				Frame = scroller.Bounds
			};

			var column = new NSTableColumn {
				Width = scroller.Frame.Width
			};
			ImageSelectorView.AddColumn (column);

			scroller.DocumentView = ImageSelectorView;
			ImageSelector.AddSubview (scroller);
		}

		void CreateImageCarouselView ()
		{
			var scroller = new NSScrollView (ImageViewer.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = false,
			};

			ImageCarouselViewDataSource = new ImageCarouselViewDataSource ();
			ImageCarouselView = new ImageCarouselView {
				AutoresizingMask = NSViewResizingMask.WidthSizable,
				DataSource = ImageCarouselViewDataSource,
				Frame = ImageViewer.Bounds,
			};

			scroller.DocumentView = ImageCarouselView;
			ImageViewer.AddSubview (scroller);
			ImageCarouselView.ReloadData ();
		}

		void CreateXmlViewer ()
		{
			var scroller = new NSScrollView (CodeViewer.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
				Frame = CodeViewer.Bounds,
			};

			XmlViewer = new NSTextField (scroller.Bounds) {
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
			};
			XmlViewer.StringValue = string.Concat (new [] {
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
				Environment.NewLine,
				"Asd asd sdf fdghfh ghj ghj dfgsd fg",
			});

			scroller.DocumentView = XmlViewer;
			CodeViewer.AddSubview (scroller);
		}

		#endregion
	}
}

