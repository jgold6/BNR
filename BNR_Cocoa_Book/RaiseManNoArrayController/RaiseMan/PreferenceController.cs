
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace RaiseMan
{
    public partial class PreferenceController : MonoMac.AppKit.NSWindowController
    {
		#region - Member variables and properties
		//strongly typed window accessor
		public new Preference Window
		{
			get
			{
				return (Preference)base.Window;
			}
		}
		#endregion

        #region Constructors
        // Called when created from unmanaged code
        public PreferenceController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public PreferenceController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public PreferenceController() : base("Preference")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
        }
        #endregion

		#region - LifeCycle
		public override void WindowDidLoad()
		{
			base.WindowDidLoad();
			Console.WriteLine("Nib file is loaded");

			colorWell.Color = PreferenceController.PreferenceTableBgColor();
			checkBox.State = PreferenceController.PreferenceEmptyDoc() ? NSCellStateValue.On : NSCellStateValue.Off;

			// Close color panel when preferences panel closes.
			Window.WillClose += (object sender, EventArgs e) => {
				Console.WriteLine("Preferences closed");
				if (NSColorPanel.SharedColorPanelExists) {
					NSColorPanel.SharedColorPanel.OrderOut(null);
					colorWell.Deactivate();
				}
			};
		}
		#endregion

		#region = Actions
		partial void ChangeBackgroundColor (NSObject sender)
		{
			NSColor color = colorWell.Color;
			Console.WriteLine("Color preference changed: {0}", color);
			PreferenceController.SetPreferenceTablebgColor(color);

			NSNotificationCenter nc = NSNotificationCenter.DefaultCenter;
			NSDictionary d = NSDictionary.FromObjectAndKey(color, DefaultStrings.RMColor);
			nc.PostNotificationName(DefaultStrings.RMColorChangedNotification.ToString(), this, d);
			Console.WriteLine("Color change notification sent: {0}", color);
		}

		partial void ChangeNewEmptyDoc (NSObject sender)
		{
			NSCellStateValue state = checkBox.State;
			Console.WriteLine("Checkbox changed: {0}", (state == NSCellStateValue.Off ? "off" : "on"));
			PreferenceController.SetPreferenceEmptyDoc(state == NSCellStateValue.On ? true : false);
		}

		partial void RestoreDefaults (MonoMac.Foundation.NSObject sender)
		{
			PreferenceController.SetPreferenceTablebgColor(NSColor.White);
			colorWell.Color = NSColor.White;
			PreferenceController.SetPreferenceEmptyDoc(true);
			checkBox.State = NSCellStateValue.On;
		}
		#endregion

		#region - Get and set user defaults
		public static NSColor PreferenceTableBgColor()
		{
			NSUserDefaults defaults = NSUserDefaults.StandardUserDefaults;
			NSData colorAsData = (NSData)defaults.ValueForKey(DefaultStrings.RMTableBgColorKey);
			return (NSColor)NSKeyedUnarchiver.UnarchiveObject(colorAsData);
		}

		public static void SetPreferenceTablebgColor(NSColor color)
		{
			NSData colorAsData = NSKeyedArchiver.ArchivedDataWithRootObject(color);
			NSUserDefaults.StandardUserDefaults.SetValueForKey(colorAsData, DefaultStrings.RMTableBgColorKey);
		}

		public static bool PreferenceEmptyDoc()
		{
			NSUserDefaults defaults = NSUserDefaults.StandardUserDefaults;
			return defaults.BoolForKey(DefaultStrings.RMEmptyDocKey);
		}

		public static void SetPreferenceEmptyDoc(bool emptyDoc)
		{
			NSUserDefaults.StandardUserDefaults.SetBool(emptyDoc, DefaultStrings.RMEmptyDocKey);
		}
		#endregion
    }
}

