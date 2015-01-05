// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace RaiseMan
{
	partial class AppController
	{
		[Outlet]
		MonoMac.AppKit.NSPanel aboutPanel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (aboutPanel != null) {
				aboutPanel.Dispose ();
				aboutPanel = null;
			}
		}
	}
}
