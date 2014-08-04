using System;
using MonoMac.AppKit;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace VisualTestComparer
{
	public class ImageTestView : NSTableView
	{
		public Queue<string> iOSVersions {
			get;
			set;
		}

		public NSScrollView scroller {
			get;
			set;
		}

		// want this to take in info
		public ImageTestView (Queue<string> iOSVersions, NSScrollView scroller)
		{
			this.iOSVersions = iOSVersions;
			this.scroller = scroller;
			BuildColumns ();
		}



		public void BuildColumns(){

			var colCount = iOSVersions.Count;
			while (iOSVersions.Count != 0) {

				var version = (string)iOSVersions.Dequeue ();
				var column = new NSTableColumn {
					Width = (scroller.Frame.Width/colCount),
					HeaderCell = new NSTextFieldCell(version),
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
			var imageDictionary = selectedTest.imageDictionary;
		/*	foreach (var pair in imageDictionary) {
				Console.WriteLine (pair.ToString ());

			}*/
			var version = tableColumn.Identifier;
			string path;
			path = row == 0 ? imageDictionary ["master" + version] : imageDictionary ["fail" + version];
			var newView = new NSImageView();
			newView.Image = new NSImage(path);
			return newView;

		}

	}

		


}

