
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.QTKit;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Security.Cryptography;

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

			CreateXmlViewer ();
			CreateImageSelectorView ();
		//	CreateImageCarouselView ();

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

			var imageScroller = new NSScrollView (ImageSelector.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
			};
		
			//this.ImageSelectorDataSource = new ImageSelectorDataSource ();
			this.ImageSelectorView = new ImageSelectorView {
			//	DataSource = ImageSelectorDataSource,
			//	Delegate = ImageSelectorDelegate,
				Frame = scroller.Bounds
			};

			this.ImageSelectorDelegate = new ImageSelectorDelegate (XmlViewer, ImageSelectorView, ImageViewer);
			this.ImageSelectorDataSource = new ImageSelectorDataSource (ImageSelectorDelegate.NumberOfItems ());

			this.ImageSelectorView.Delegate = ImageSelectorDelegate;
			this.ImageSelectorView.DataSource = ImageSelectorDataSource;
			var column = new NSTableColumn {
				Width = scroller.Frame.Width,
				//HeaderCell = new NSTextFieldCell("Item")
			};
					
			ImageSelectorView.AddColumn (column);
			ImageSelector.AcceptsTouchEvents = true;
			scroller.DocumentView = ImageSelectorView;
			ImageSelector.AddSubview (scroller);
			//ImageSelectorView.AcceptsTouchEvents = true;
			//ImageSelectorView.DidClickTableColumn += changeXMLView;

		//	ImageViewer.AddSubview (imageScroller);


		}

	/*	void CreateImageCarouselView ()
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
*/
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
				
			scroller.DocumentView = XmlViewer;
			CodeViewer.AddSubview (scroller);
		}

		/*
		void changeXMLView(object sender, EventArgs e)
		{
			ImageTest test = ImageSelectorDataSource.Images [(ImageSelectorView.SelectedRow)];
			XElement element = test.snippet.GetValue (null, null) as XElement;

			XmlViewer.StringValue = element.ToString(); 

		}
	*/




		#endregion
	}
}

