// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace VisualTestComparer
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		MonoMac.AppKit.NSView CodeViewer { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView ImageSelector { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView ImageViewer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageSelector != null) {
				ImageSelector.Dispose ();
				ImageSelector = null;
			}

			if (ImageViewer != null) {
				ImageViewer.Dispose ();
				ImageViewer = null;
			}

			if (CodeViewer != null) {
				CodeViewer.Dispose ();
				CodeViewer = null;
			}
		}
	}

	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
