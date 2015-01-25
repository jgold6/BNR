using System;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;
using MonoMac.ObjCRuntime;

namespace RaiseMan
{
	[Register("AppController")]
    public partial class AppController : NSApplicationDelegate
    {
		#region - Member variables and properties
		PreferenceController preferenceController;
		static bool sFirstLaunch;
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

			sFirstLaunch = true;
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
			if (NSApplication.SharedApplication.MainWindow != null) {
				var mainWindowFrame = NSApplication.SharedApplication.MainWindow.Frame;
				float x = mainWindowFrame.X + mainWindowFrame.Width/2 - aboutPanel.Frame.Width/2;
				float y = mainWindowFrame.Y + mainWindowFrame.Height/2 - aboutPanel.Frame.Height/2;
				aboutPanel.SetFrame(new RectangleF(x, y, aboutPanel.Frame.Width, aboutPanel.Frame.Height), true);
			}
			else {
				NSScreen screen = NSScreen.MainScreen;
				aboutPanel.SetFrame(new RectangleF(screen.Frame.Width/2-aboutPanel.Frame.Width/2, screen.Frame.Height - aboutPanel.Frame.Height - 100, aboutPanel.Frame.Width, aboutPanel.Frame.Height), true);
			}
			// Stop modal when about panel closed.
			aboutPanel.WillClose += (object s, EventArgs e) =>  {
				Console.WriteLine("Window will close");
				NSApplication.SharedApplication.StopModal();
			};
			// Show modal about panel
			NSApplication.SharedApplication.RunModalForWindow(aboutPanel);
		}

		// Manual implemenation of NSDocumentController's openDocument: method
		[Action ("showNSOpenPanel:")]
		public void ShowNSOpenPanel (MonoMac.Foundation.NSObject sender)
		{
			NSOpenPanel openPanel = NSOpenPanel.OpenPanel;
			openPanel.AllowsMultipleSelection = true;
			openPanel.AllowedFileTypes = new string[]{"rsmn"};

			int result = openPanel.RunModal();

			if (result == 1) {
				NSUrl[]  theDocs = openPanel.Urls;
				NSError outError = null;
				foreach (NSUrl theDoc in theDocs)
					NSDocumentController.SharedDocumentController.OpenDocument(theDoc, true, out outError);
			}
		}
		#endregion

		#region - delegate methods
		public override bool ApplicationShouldOpenUntitledFile(NSApplication sender)
		{
			Console.WriteLine("ApplicationShouldOpenUntitledFile called");
			return PreferenceController.PreferenceEmptyDoc;
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (sFirstLaunch)
			{
				ChangeMenuItemTitle("RaiseMan", "About RaiseMan", "ABOUT_RAISEMAN");
				ChangeMenuItemTitle("RaiseMan", "Preferences…", "PREFERENCES");
				ChangeMenuItemTitle("Edit", "New Employee", "NEW_EMPLOYEE");
				ChangeMenuItemTitle("Edit", "Remove Employee", "REMOVE_EMPLOYEE");
				sFirstLaunch = false;
			}
		}

		// Chapter 14 challenge
//		public override void DidResignActive(NSNotification notification)
//		{
//			AppKitFramework.NSBeep();
//		}
		#endregion

		#region - Helpers
		public void ChangeMenuItemTitle(string topMenuName, string itemName, string localizationKey)
		{
			NSMenu menu = NSApplication.SharedApplication.MainMenu;
			NSMenuItem fileMenu = menu.ItemWithTitle(topMenuName).Submenu.ItemWithTitle(itemName);
			fileMenu.Title = NSBundle.MainBundle.LocalizedString(localizationKey, null);
		}
		#endregion
    }
}

