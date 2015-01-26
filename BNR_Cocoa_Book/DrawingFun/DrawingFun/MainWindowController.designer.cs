// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrawingFun
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		DrawingFun.StretchView stretchView { get; set; }

		[Action ("showOpenPanel:")]
		partial void ShowOpenPanel (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (stretchView != null) {
				stretchView.Dispose ();
				stretchView = null;
			}
		}
	}
}
