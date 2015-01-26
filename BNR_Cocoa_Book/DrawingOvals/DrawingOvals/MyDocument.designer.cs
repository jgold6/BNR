// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrawingOvals
{
	[Register ("MyDocument")]
	partial class MyDocument
	{
		[Outlet]
		DrawingOvals.StretchView stretchView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (stretchView != null) {
				stretchView.Dispose ();
				stretchView = null;
			}
		}
	}
}
