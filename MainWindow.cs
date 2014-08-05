
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

			//Need to create the XmlView first to pass it
			// to the ImageSelectorDelegate
			CreateXmlViewer ();
			CreateImageSelectorView ();

		}

		void CreateImageSelectorView ()
		{
			// Create the Image Selector Scroller
			var scroller = new NSScrollView (ImageSelector.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
			};

			// Create the Image Viewer scroller
			var imageScroller = new NSScrollView (ImageSelector.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
			};
		
			//Create the Image Selector View
			this.ImageSelectorView = new ImageSelectorView {
				Frame = scroller.Bounds
			};

			// Create the ImageSelectorDelegate, pass it all three views
			this.ImageSelectorDelegate = new ImageSelectorDelegate (XmlViewer, ImageSelectorView, ImageViewer);

			// Create the Data Source for the ImageSelector, pass it the number of items
			this.ImageSelectorDataSource = new ImageSelectorDataSource (ImageSelectorDelegate.NumberOfItems ());

			// Assign the Delegate and DataSource 
			this.ImageSelectorView.Delegate = ImageSelectorDelegate;
			this.ImageSelectorView.DataSource = ImageSelectorDataSource;

			//Create the column for the Image Selector 
			var column = new NSTableColumn {
				Width = scroller.Frame.Width,
			};

			// Add the column to the Image Selector View 
			ImageSelectorView.AddColumn (column);
			// Allow the selector to accept touch events
			ImageSelector.AcceptsTouchEvents = true;

			// Connect the ImageSelectorView to the xib
			scroller.DocumentView = ImageSelectorView;
			ImageSelector.AddSubview (scroller);



		}
			
		void CreateXmlViewer ()
		{
			// Create Scroller for XML
			var scroller = new NSScrollView (CodeViewer.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
				Frame = CodeViewer.Bounds,
			};

			// Have the XML displayed in a NSTextField
			XmlViewer = new NSTextField (scroller.Bounds) {
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
			};
				
		  // Connect the view to the xib
			scroller.DocumentView = XmlViewer;
			CodeViewer.AddSubview (scroller);
		}






		#endregion
	}
}

