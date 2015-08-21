// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HypnoTime
{
	[Register ("MapViewController")]
	partial class MapViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView actIndicator { get; set; }

		[Outlet]
		MapKit.MKMapView mapView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl segControl { get; set; }

		[Outlet]
		UIKit.UITextField textField { get; set; }
		
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
