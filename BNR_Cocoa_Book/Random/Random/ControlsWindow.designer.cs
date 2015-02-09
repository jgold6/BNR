// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Random
{
	[Register ("ControlsController")]
	partial class ControlsController
	{
		[Outlet]
		AppKit.NSProgressIndicator circularProgressIndicator { get; set; }

		[Outlet]
		AppKit.NSSlider circularSlider { get; set; }

		[Outlet]
		AppKit.NSColorWell colorWell { get; set; }

		[Outlet]
		AppKit.NSComboBox comboBox { get; set; }

		[Outlet]
		AppKit.NSButton disclosureArrow { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator horizontalProgressIndicator { get; set; }

		[Outlet]
		AppKit.NSSlider horizontalSlider { get; set; }

		[Outlet]
		AppKit.NSImageView imageView { get; set; }

		[Outlet]
		AppKit.NSLevelIndicator levelIndicator { get; set; }

		[Outlet]
		AppKit.NSPathControl pathControl { get; set; }

		[Outlet]
		AppKit.NSPopUpButton popUpButton { get; set; }

		[Outlet]
		AppKit.NSSearchField searchField { get; set; }

		[Outlet]
		AppKit.NSSegmentedControl segmentedControl { get; set; }

		[Outlet]
		AppKit.NSTextField textField { get; set; }

		[Outlet]
		AppKit.NSTokenField tokenField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (searchField != null) {
				searchField.Dispose ();
				searchField = null;
			}

			if (segmentedControl != null) {
				segmentedControl.Dispose ();
				segmentedControl = null;
			}

			if (popUpButton != null) {
				popUpButton.Dispose ();
				popUpButton = null;
			}

			if (circularSlider != null) {
				circularSlider.Dispose ();
				circularSlider = null;
			}

			if (horizontalSlider != null) {
				horizontalSlider.Dispose ();
				horizontalSlider = null;
			}

			if (comboBox != null) {
				comboBox.Dispose ();
				comboBox = null;
			}

			if (horizontalProgressIndicator != null) {
				horizontalProgressIndicator.Dispose ();
				horizontalProgressIndicator = null;
			}

			if (circularProgressIndicator != null) {
				circularProgressIndicator.Dispose ();
				circularProgressIndicator = null;
			}

			if (pathControl != null) {
				pathControl.Dispose ();
				pathControl = null;
			}

			if (disclosureArrow != null) {
				disclosureArrow.Dispose ();
				disclosureArrow = null;
			}

			if (levelIndicator != null) {
				levelIndicator.Dispose ();
				levelIndicator = null;
			}

			if (colorWell != null) {
				colorWell.Dispose ();
				colorWell = null;
			}

			if (tokenField != null) {
				tokenField.Dispose ();
				tokenField = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
		}
	}

	[Register ("ControlsWindow")]
	partial class ControlsWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
