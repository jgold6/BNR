
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Diagnostics;

namespace Random
{
    public partial class MainWindowController : AppKit.NSWindowController
    {
		static readonly string TAG = "MainWindowController";

		System.Random random;

		#region Constructors
        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
			random = new System.Random();
        }

        #endregion

		#region - LifeCycle
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			mainView.Layer = new CoreAnimation.CALayer();
			mainView.WantsLayer = true;
			mainView.Layer.BackgroundColor = NSColor.White.CGColor;

			var now = DateTime.Now;
			textField.StringValue = String.Format("{0}, {1}", now.ToLongDateString(), now.ToLongTimeString());
		}

		#endregion

		#region - Actions
		partial void seed (Foundation.NSObject sender)
		{
			NSButton btn = (NSButton)sender;
			Debug.WriteLine("[{0}] {1} Action clicked.", TAG, btn.Title);

			TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1).ToUniversalTime()); 
			random = new System.Random((int)Math.Floor(t.TotalMilliseconds));

			textField.StringValue = "Generator seeded"; 
		}

		partial void generate (Foundation.NSObject sender)
		{
			NSButton btn = (NSButton)sender;
			Debug.WriteLine("[{0}] {1} Action clicked.", TAG, btn.Title);

			System.Random rnd = new System.Random();
			int generated = rnd.Next(1, 101);

			textField.IntValue = generated;

		}

		partial void openModal (Foundation.NSObject sender)
		{
			ControlsController controlsController = new ControlsController();
			NSApplication.SharedApplication.RunModalForWindow(controlsController.Window);
		}
		#endregion

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }
    }

	public class TestMethods
	{
		public static string GetString()
		{
			return "Success!";
		}
	}
}

