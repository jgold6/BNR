using System;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;
using MonoMac.ObjCRuntime;

namespace RaiseMan
{
	[Register("AppController")]
    public partial class AppController : NSObject
    {
		#region - Member variables and properties
		PreferenceController preferenceController;
		#endregion

		#region Constructors
		// Called when created from unmanaged code
		public AppController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		[Export("initialize")]
		public static void ClassInitialize()
		{
			// Create a Defaults dictionary
			NSMutableDictionary defaultValues = new NSMutableDictionary();

			// Archive the color object
			NSData colorAsData = NSKeyedArchiver.ArchivedDataWithRootObject(NSColor.White);

			// Put defaults in the dictionary
			defaultValues.SetValueForKey(colorAsData, DefaultStrings.RMTableBgColorKey);
			defaultValues.SetValueForKey(NSNumber.FromBoolean(true), DefaultStrings.RMEmptyDocKey);

			// Register the dictionary of defaults
			NSUserDefaults.StandardUserDefaults.RegisterDefaults(defaultValues);
			Console.WriteLine("Registered defaults: {0}", defaultValues);
		}
		#endregion

		#region - Actions
		[Action ("showPreferencePanel:")]
		public void ShowPreferencePanel (MonoMac.Foundation.NSObject sender)
		{
			// Is preference controller null?
			if (preferenceController == null) {
				preferenceController = new PreferenceController();
				Preference prefWindow = preferenceController.Window;
				float x, y;
				if (NSApplication.SharedApplication.MainWindow != null) {
					x = NSApplication.SharedApplication.MainWindow.Frame.X + NSApplication.SharedApplication.MainWindow.Frame.Width + 20;
					y = NSApplication.SharedApplication.MainWindow.Frame.Y;
				}
				else {
					x = 100;
					y = 500;
				}
				prefWindow.SetFrame(new RectangleF(x, y, prefWindow.Frame.Width, prefWindow.Frame.Height), false);
			}
			Console.WriteLine("Showing {0}", preferenceController);
			preferenceController.ShowWindow(this);
		}

		[Action ("showAboutPanel:")]
		public void ShowAboutPanel (MonoMac.Foundation.NSObject sender)
		{
			// The strict chap 12 challenge solution. non-modal, no window controller for the about panel
			// so multiple about panels can be displayed
//			NSBundle.LoadNib("About", this);
//			aboutPanel.MakeKeyAndOrderFront(null);

			// Make about panel modal and position it in the center of the active window
			NSBundle.LoadNib("About", this);
			// Change BG color and posiiton
			aboutPanel.BackgroundColor = NSColor.White;
			var mainWindowFrame = NSApplication.SharedApplication.MainWindow.Frame;
			float x = mainWindowFrame.X + mainWindowFrame.Width/2 - aboutPanel.Frame.Width/2;
			float y = mainWindowFrame.Y + mainWindowFrame.Height/2 - aboutPanel.Frame.Height/2;
			aboutPanel.SetFrame(new RectangleF(x, y, aboutPanel.Frame.Width, aboutPanel.Frame.Height), true);
			// Stop modal when about panel closed.
			aboutPanel.WillClose += (object s, EventArgs e) =>  {
				Console.WriteLine("Window will close");
				NSApplication.SharedApplication.StopModal();
			};
			// Show modal about panel
			NSApplication.SharedApplication.RunModalForWindow(aboutPanel);
		}
		#endregion

		[Export("applicationShouldOpenUntitledFile:")]
		public bool ShouldOpenUntitledFile(NSApplication sender)
		{
			Console.WriteLine("ApplicationShouldOpenUntitledFile called");
			return PreferenceController.PreferenceEmptyDoc();
		}
    }
}

