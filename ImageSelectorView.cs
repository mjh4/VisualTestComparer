using System;
using System.Collections.Generic;

using MonoMac.AppKit;
using MonoMac.Foundation;

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
		public override float GetSizeToFitColumnWidth (NSTableView tableView, int column)
		{
			return tableView.Bounds.Width;
		}
	}

	class ImageSelectorDataSource : NSTableViewDataSource
	{
		public List<NSString> Images {
			get; set;
		}

		public ImageSelectorDataSource ()
		{
			Images = new List<NSString> ();
			for (int i = 0; i < 100; i++) {
				Images.Add ((NSString) ("text" + i));
			}
		}

		public override int GetRowCount (NSTableView tableView)
		{
			return Images.Count;
		}

		public override void SetObjectValue (NSTableView tableView, MonoMac.Foundation.NSObject theObject, NSTableColumn tableColumn, int row)
		{

		}

		public override MonoMac.Foundation.NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			return Images [row];
		}
	}
}

