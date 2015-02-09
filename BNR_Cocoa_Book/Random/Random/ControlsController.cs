
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Random
{
	public partial class ControlsController : AppKit.NSWindowController
    {
		static readonly string TAG = "ControlsController";

        #region Constructors

        // Called when created from unmanaged code
        public ControlsController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ControlsController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
		// Call to load from the XIB/NIB file
		public ControlsController() : base("Controls")
		{
			Initialize();
		}

        // Shared initialization code
        void Initialize()
        {
        }
		#endregion

		#region - LifeCycle
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			circularProgressIndicator.MinValue = 0;
			circularProgressIndicator.MaxValue = 100;
			circularProgressIndicator.DoubleValue = 50.0;
			circularProgressIndicator.Indeterminate = false;
			// Only if Indeterminate = true;
//			circularProgressIndicator.StartAnimation(this);

			horizontalProgressIndicator.MinValue = 0;
			horizontalProgressIndicator.MaxValue = 100;
			horizontalProgressIndicator.DoubleValue = 50.0;
			horizontalProgressIndicator.Indeterminate = false;
			// Only if Indeterminate = true;
//			horizontalProgressIndicator.StartAnimation(this);

			circularSlider.Continuous = true;
			circularSlider.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("CircularSlider Value: {0}", circularSlider.StringValue);
				horizontalSlider.FloatValue = circularSlider.FloatValue;
				horizontalProgressIndicator.DoubleValue = circularSlider.DoubleValue;
				circularProgressIndicator.DoubleValue = circularSlider.DoubleValue;
			};

			horizontalSlider.Continuous = true;
			horizontalSlider.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("HorizontalSlider Value: {0}", horizontalSlider.StringValue);
				circularSlider.FloatValue = horizontalSlider.FloatValue;
				horizontalProgressIndicator.DoubleValue = horizontalSlider.DoubleValue;
				circularProgressIndicator.DoubleValue = horizontalSlider.DoubleValue;
			};
			
			colorWell.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("ColorWell Value: {0}", colorWell.Color.ToString());
			};

			comboBox.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("ComboBox Final Value: {0}", comboBox.StringValue);
			};
			comboBox.Changed += (object sender, EventArgs e) => {
				Console.WriteLine("ComboBox Changed: {0}", comboBox.StringValue);
			};

			disclosureArrow.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("DisclosureArrow State: {0}", disclosureArrow.State);
			};

			imageView.Image = NSImage.ImageNamed("LittleBeach.png");

			levelIndicator.MaxValue = 10;
			levelIndicator.MinValue = 0;
			levelIndicator.IntValue = 5;
			levelIndicator.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("LevelIndicator Value: {0}", levelIndicator.IntValue);
			};

			pathControl.Url = NSUrl.FromString("/Users/apple/Desktop");
			pathControl.Activated += (object sender, EventArgs e) => {
				if (pathControl.ClickedPathComponentCell != null)
					Console.WriteLine("PathControl Path: {0}", pathControl.ClickedPathComponentCell.Title);
				else
					Console.WriteLine("PathControl Path: {0}", "Empty area clicked");
			};

			popUpButton.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("PopUpButton Final Value: {0}", popUpButton.SelectedItem.Title);
			};

			searchField.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("SearchField Final Value: {0}", searchField.StringValue);
			};
			searchField.Changed += (object sender, EventArgs e) => {
				Console.WriteLine("SearchField Changed: {0}", searchField.StringValue);
			};

			segmentedControl.SegmentCount = 6;
			segmentedControl.SetLabel ("One", 0);
			segmentedControl.SetLabel ("Two", 1);
			segmentedControl.SetLabel ("Three", 2);
			segmentedControl.SetLabel ("Four", 3);
			segmentedControl.SetLabel ("Five", 4);
			segmentedControl.SetLabel ("Close", 5);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 0);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 1);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 2);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 3);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 4);
			segmentedControl.SetWidth(segmentedControl.Frame.Width/6, 5);
			segmentedControl.SelectedSegment = 3;
			segmentedControl.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("SegmentedControl Value: {0}", segmentedControl.GetLabel(segmentedControl.SelectedSegment));
				if (segmentedControl.SelectedSegment == 5)
					this.Window.PerformClose(this);
			};

			textField.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("TextField Final Value: {0}", textField.StringValue);
			};
			textField.Changed += (object sender, EventArgs e) => {
				Console.WriteLine("TextField Changed: {0}", textField.StringValue);
			};

			tokenField.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("TokenField Final Value: {0}", tokenField.StringValue);
			};
			tokenField.Changed += (object sender, EventArgs e) => {
				Console.WriteLine("TokenField Changed: {0}", tokenField.StringValue);
			};
			tokenField.TokenStyle = NSTokenStyle.Default;

			this.Window.WindowShouldClose += (NSObject sender) => {
				Console.WriteLine("Window should close");
				NSApplication.SharedApplication.StopModal();
				return true;
			};
		}

		#endregion

		//strongly typed window accessor
		public new ControlsWindow Window
		{
			get
			{
				return (ControlsWindow)base.Window;
			}
		}
    }

	[Register("MyImage")]
	public class MyImage : NSImageView
	{
		public MyImage(IntPtr handle) : base(handle)
		{
		}

		public override void MouseDown(NSEvent theEvent)
		{
			base.MouseDown(theEvent);
			Console.WriteLine("MyImage Clicked: {0}", this.ConvertPointFromView(theEvent.LocationInWindow, this.Superview));
		}
	}
}

