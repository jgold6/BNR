// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace HypnoTime
{
	[Register ("MapViewController")]
	partial class MapViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView actIndicator { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segControl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}

			if (segControl != null) {
				segControl.Dispose ();
				segControl = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (actIndicator != null) {
				actIndicator.Dispose ();
				actIndicator = null;
			}
		}
	}
}
