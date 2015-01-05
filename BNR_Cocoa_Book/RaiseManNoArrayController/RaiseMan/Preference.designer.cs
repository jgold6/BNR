using MonoMac.Foundation;
using MonoMac.AppKit;


namespace RaiseMan
{
    
    // Should subclass MonoMac.AppKit.NSWindow
    [MonoMac.Foundation.Register("Preference")]
    public partial class Preference
    {
    }
    
    // Should subclass MonoMac.AppKit.NSWindowController
    [MonoMac.Foundation.Register("PreferenceController")]
    public partial class PreferenceController
    {
		[Outlet]
		public NSColorWell colorWell { get; set; }

		[Outlet]
		public NSButton checkBox { get; set; }

		[Action ("changeBackgroundColor:")]
		partial void ChangeBackgroundColor (MonoMac.Foundation.NSObject sender);

		[Action ("changeNewEmptyDoc:")]
		partial void ChangeNewEmptyDoc (MonoMac.Foundation.NSObject sender);

		[Action ("restoreDefaults:")]
		partial void RestoreDefaults (MonoMac.Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (colorWell != null) {
				colorWell.Dispose ();
				colorWell = null;
			}

			if (checkBox != null) {
				checkBox.Dispose ();
				checkBox = null;
			}
		}
    }
}

