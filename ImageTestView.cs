using System;
using MonoMac.AppKit;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace VisualTestComparer
{
	public class ImageTestView : NSTableView
	{

		// Want to hold the iOSVersions we are using
		public Queue<string> iOSVersions {
			get;
			set;
		}

		// This scroller is the parent of the view
		// We need it to set the column width appropriately
		public NSScrollView scroller {
			get;
			set;
		}


		public ImageTestView (Queue<string> iOSVersions, NSScrollView scroller)
		{
			this.iOSVersions = iOSVersions;
			this.scroller = scroller;
			BuildColumns ();
		}


		// Add a column for every iOS version
		public void BuildColumns(){

			var colCount = iOSVersions.Count;
			while (iOSVersions.Count != 0) {

				var version = (string)iOSVersions.Dequeue ();
				var column = new NSTableColumn {
					Width = (scroller.Frame.Width/colCount),
					HeaderCell = new NSTextFieldCell(version),
					//ResizingMask = NSTableColumnResizing.Autoresizing,
					Identifier = version
				};

				this.AddColumn (column);

			}

		}
	}



	public class ImageTestViewDataSource : NSTableViewDataSource
	{

		public ImageTestViewDataSource()
		{

		}

		// We always should have two rows, master and test version
		public override int GetRowCount (NSTableView tableView)
		{
			return 2;
		}
	}




	public sealed class ImageTestViewDelegate : NSTableViewDelegate
	{
		public ImageTest selectedTest {
			get;
			set;
		}

		public ImageTestViewDelegate(ImageTest imageTest)
		{
			selectedTest = imageTest;
		}

		public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			//Dictionary stores image paths for specific imageTest
			var imageDictionary = selectedTest.imageDictionary;
		
			// Use the version of the column to access the dictionary 
			var version = tableColumn.Identifier;
			// If we are looking at row 0, grab master version, otherwise grab test version
			string path = row == 0 ? imageDictionary ["master" + version] : imageDictionary ["fail" + version];

			// Create the NSImageView using the correct path
			var newView = new NSImageView();
			newView.Image = new NSImage(path);
			return newView;

		}

	}

		


}

