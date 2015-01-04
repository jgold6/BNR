using System;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;
using MonoMac.ObjCRuntime;

namespace RaiseMan
{
	[Register("AppController")]
    public class AppController : NSObject
    {
		PreferenceController preferenceController;
		AboutController aboutController;

		[Action ("showPreferencePanel:")]
		public void ShowPreferencePanel (MonoMac.Foundation.NSObject sender)
		{
			// Is preference controller null?
			if (preferenceController == null) {
				preferenceController = new PreferenceController();
				Preference prefWindow = preferenceController.Window;
				float x = NSApplication.SharedApplication.MainWindow.Frame.X + NSApplication.SharedApplication.MainWindow.Frame.Width + 20;
				float y = NSApplication.SharedApplication.MainWindow.Frame.Y;
				prefWindow.SetFrame(new RectangleF(x, y, prefWindow.Frame.Width, prefWindow.Frame.Height), false);
			}
			Console.WriteLine("Showing {0}", preferenceController);
			preferenceController.ShowWindow(this);
		}

		[Action ("showAboutPanel:")]
		public void ShowAboutPanel (MonoMac.Foundation.NSObject sender)
		{
			// Is aboutPanel null?
			if (aboutController == null) {
				aboutController = new AboutController();
				About aboutWindow = aboutController.Window;
				aboutWindow.BackgroundColor = NSColor.White;
				var mainWindowFrame = NSApplication.SharedApplication.MainWindow.Frame;
				float x = mainWindowFrame.X + mainWindowFrame.Width/2 - aboutWindow.Frame.Width/2;
				float y = mainWindowFrame.Y + mainWindowFrame.Height/2 - aboutWindow.Frame.Height/2;
				aboutController.Window.SetFrame(new RectangleF(x, y, aboutWindow.Frame.Width, aboutWindow.Frame.Height), false);
				aboutWindow.WindowShouldClose += (NSObject s) => {
					Console.WriteLine("Window should close");
					NSApplication.SharedApplication.StopModal();
					return true;
				};
			}
			Console.WriteLine("Showing {0}", aboutController);
			NSApplication.SharedApplication.RunModalForWindow(aboutController.Window);
		}
    }
}

