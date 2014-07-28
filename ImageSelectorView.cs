using System;
using System.Collections.Generic;
using System.IO;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Collections;
using System.Threading;
using System.Xml.Linq;



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




		public override float GetSizeToFitColumnWidth (NSTableView tableView, int column)
		{
			return tableView.Bounds.Width;
		}

		public ImageSelectorDelegate(NSTextField xViewer, ImageSelectorView aView)
		{
			theView = aView;

			//Assign the NSTextField given to our XmlViewer
			XmlViewer = xViewer;

			Images = new List<ImageTest> ();
			IEnumerable masterDirectories;
			IEnumerable failDirectories;
			string masterPath = "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/Masters/";
			string failPath = "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/VisualFailures/";
			masterDirectories = Directory.EnumerateDirectories (masterPath);
			failDirectories = Directory.EnumerateDirectories (failPath);
			foreach (string path in masterDirectories) {
				Console.WriteLine (path);
			}


			Images = new List<ImageTest> ();
			var snippets = typeof (ViewSnippets).GetProperties (System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
			foreach (var snippet in snippets) {
				Images.Add (new ImageTest (snippet, masterDirectories, failDirectories));
			}

		}


		public override void SelectionDidChange (NSNotification notification)
		{
			var snippet = (Images [theView.SelectedRow]).snippet;

			var element = snippet.GetValue (null, null) as XElement;

			XmlViewer.StringValue = element.ToString ();


		}
			

		const string Identifier = "HotnessView";
		public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			var snippet = Images [row];
			NSTextField f = tableView.MakeView (Identifier, this) as NSTextField;
			if (f == null) {
				f = new NSTextField ();
				f.AllowsEditingTextAttributes = true;
				f.Identifier = Identifier;
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



	}

	class ImageSelectorDataSource : NSTableViewDataSource
	{





		public ImageSelectorDataSource ()
		{
				
		}

		public override int GetRowCount (NSTableView tableView)
		{
			return 20;

			}	


	

		/*
		public override MonoMac.Foundation.NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, int row)
		{

			// HEY CHRIS! HERE IS WHERE I WANT TO CHANGE THE COLOR

			var snippet = Images [row];

			var theCell = new NSCell (snippet.name);
			//if (!snippet.noVisualFail)
			//	Change The cell color
			return theCell;
		
		}*/


	}
}

