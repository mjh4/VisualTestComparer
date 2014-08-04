using System;
using System.Collections.Generic;
using System.IO;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Collections;
using System.Threading;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;



namespace VisualTestComparer
{

	public class ImageSelectorView : NSTableView
	{



		public ImageSelectorView ()
		{



		}
	}

	class ImageSelectorDelegate : NSTableViewDelegate
	{
		public ImageSelectorView theView {
			get;
			set;
		}


		public List<ImageTest> Images {
			get; set;
		}

		public NSTextField XmlViewer {
			get;
			set;
		}

		public Queue<string> iOSVersions {
			get;
			set;
		}

		public ImageTestView ImageTestView {
			get;
			set;
		}

		public ImageTestViewDelegate ImageTestViewDelegate {
			get;
			set;
		}

		public ImageTestViewDataSource ImageTestViewDataSource {
			get;
			set;
		}




		public override float GetSizeToFitColumnWidth (NSTableView tableView, int column)
		{
			return tableView.Bounds.Width;
		}

		public ImageSelectorDelegate(NSTextField xViewer, ImageSelectorView aView, NSView ImageViewer)
		{
			theView = aView;

			//Assign the NSTextField given to our XmlViewer
			XmlViewer = xViewer;


			Images = new List<ImageTest> ();
			iOSVersions = new Queue<string> ();
			IEnumerable masterDirectories;
			IEnumerable failDirectories;
			string masterPath = "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/Masters/";
			string failPath = "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/VisualFailures/";
			masterDirectories = Directory.EnumerateDirectories (masterPath);
			failDirectories = Directory.EnumerateDirectories (failPath);

			//Just get the iOS names
			foreach (string path in masterDirectories) {
				var newpath = (path.Remove (0, 74));
				Console.WriteLine (newpath);
				iOSVersions.Enqueue (newpath);

			}

			//Add Individual Tests to Images
			Images = new List<ImageTest> ();
			var snippets = typeof (ViewSnippets).GetProperties (System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
			foreach (var snippet in snippets) {
				Images.Add (new ImageTest (snippet, masterDirectories, failDirectories));
			}


			//Make Table of Images
			MakeTestTable (ImageViewer);

	
		}


		public override void SelectionDidChange (NSNotification notification)
		{

			//Update the XmlViewer
			var snippet = (Images [theView.SelectedRow]).snippet;

			var element = snippet.GetValue (null, null) as XElement;

			XmlViewer.StringValue = element.ToString ();

			ImageTestViewDelegate.selectedTest = Images [theView.SelectedRow];
			ImageTestView.ReloadData ();
		}
			

	//	const string Identifier = "HotnessView";
		public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			var snippet = Images [row];
			NSTextField f = tableView.MakeView ("Items", this) as NSTextField;
			if (f == null) {
				f = new NSTextField ();
				f.AllowsEditingTextAttributes = true;
			//	f.Identifier = Identifier;
			}

			f.StringValue = snippet.name;
			if (!snippet.noVisualFail || !snippet.mastersValid) {
				f.TextColor = NSColor.Red;
			}

			
			return f;
		}

		public override float GetRowHeight (NSTableView tableView, int row)
		{
			return 25;
		}

		public int NumberOfItems(){

			return Images.Count;
		}


		public void MakeTestTable(NSView ImageViewer){

			var scroller = new NSScrollView (ImageViewer.Bounds) {
				AutohidesScrollers = true,
				AutoresizesSubviews = true,
				AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable,
				HasHorizontalScroller = true,
				HasVerticalScroller = true,
			};

			var newRowHeight = scroller.Bounds.Height / 2;
			ImageTestViewDataSource = new ImageTestViewDataSource ();
			ImageTestViewDelegate = new ImageTestViewDelegate (Images[0]);
			ImageTestView = new ImageTestView (iOSVersions, scroller) {
				Frame = scroller.Bounds,
				Delegate = ImageTestViewDelegate,
				DataSource = ImageTestViewDataSource,
				RowHeight = newRowHeight

			};

					
			scroller.DocumentView = ImageTestView;
			ImageViewer.AddSubview (scroller);
			ImageTestView.ReloadData ();


		}
			


	}

	class ImageSelectorDataSource : NSTableViewDataSource
	{

		public int rowCount {
			get;
			set;
		}




		public ImageSelectorDataSource (int number)
		{
			rowCount = number;
				
		}
			

		public override int GetRowCount (NSTableView tableView)
		{
			return rowCount;

			}	
			

	}
}

