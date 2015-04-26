
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using ObjCRuntime;
using CoreGraphics;
using System.Threading.Tasks;

namespace Departments
{
	public partial class MyDocument : AppKit.NSDocument
	{
		#region - Member variables and properties
		NSMutableArray viewControllers;

		// If this returns the name of a NIB file instead of null, a NSDocumentController
		// is automatically created for you.
		public override string WindowNibName
		{ 
			get
			{
				return "MyDocument";
			}
		}
		#endregion

		#region - Constructors
		// Called when created from unmanaged code
		public MyDocument(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
			viewControllers = new NSMutableArray();

			var dvc = new DepartmentViewController();
			var evc = new EmployeeViewController();
			viewControllers.AddObjects(new NSObject[]{dvc, evc});

			DataStore.LoadItemsFromDatabase();
		}

		#endregion

		#region - Lifecycle
		public override void WindowControllerDidLoadNib(NSWindowController windowController)
		{
			base.WindowControllerDidLoadNib(windowController);

			// Add code to here after the controller has loaded the document window

			// Populate the popup menu
			NSMenu menu = popup.Menu;

			NSViewController vc = viewControllers.GetItem<NSViewController>(0);
			NSMenuItem mi = new NSMenuItem(vc.Title, null, "");
			// Set CMD-B as the key equvialent
//			NSMenuItem mi = new NSMenuItem(vc.Title, null, "b");
//			mi.KeyEquivalentModifierMask = NSEventModifierMask.CommandKeyMask;
			menu.AddItem(mi);

			vc = viewControllers.GetItem<NSViewController>(1);
			mi = new NSMenuItem(vc.Title, null, "");
			// Set CMD-A as the key equvialent
//			mi = new NSMenuItem(vc.Title, null, "a");
//			mi.KeyEquivalentModifierMask = NSEventModifierMask.CommandKeyMask;
			menu.AddItem(mi);

			// Initially show the first controller.
			popup.SelectItem(0);
			DisplayViewController(viewControllers.GetItem<NSViewController>(0));
		}

		public override void ShouldCloseWindowController(NSWindowController windowController, NSObject delegateObject, Selector shouldCloseSelector, IntPtr contextInfo)
		{
			base.ShouldCloseWindowController(windowController, delegateObject, shouldCloseSelector, contextInfo);
		}
		#endregion

		#region - Actions
		partial void ChangeViewController (NSPopUpButton sender)
		{
			nint i = sender.IndexOfSelectedItem;
			var vc = viewControllers.GetItem<NSViewController>((nuint)i);
			Task.Run(()=> {;
				DisplayViewController(vc);
			});
		}
		#endregion

		#region - Helper methods
		private void DisplayViewController(NSViewController vc)
		{
			BeginInvokeOnMainThread(() => {
				NSWindow w = box.Window;

				bool ended = w.MakeFirstResponder(w);
				if (!ended) {
					AppKitFramework.NSBeep();
					return;
				}
				// get the new View
				NSView newView = vc.View;

				// Get the old View
				NSView oldView = (NSView)box.ContentView;

				if (oldView == newView)
					return;

				// Compute the new window frame
				CGSize currentSize = oldView.Frame.Size;
				CGSize newSize = newView.Frame.Size;

				nfloat deltaWidth = newSize.Width - currentSize.Width;
				nfloat deltaHeight = newSize.Height - currentSize.Height;
				CGRect windowframe = w.Frame;
				windowframe.Size = new CGSize(windowframe.Size.Width, windowframe.Size.Height + deltaHeight);
				windowframe.Location = new CGPoint(windowframe.Location.X, windowframe.Location.Y - deltaHeight);
				windowframe.Size = new CGSize(windowframe.Size.Width + deltaWidth, windowframe.Size.Height);


				NSDictionary windowResize = NSDictionary.FromObjectsAndKeys( new NSObject[]{w, NSValue.FromCGRect(windowframe)}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EndFrameKey});
				NSDictionary oldViewFadeOut = NSDictionary.FromObjectsAndKeys( new NSObject[]{oldView, NSViewAnimation.FadeOutEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});
				NSDictionary newViewFadeOut = NSDictionary.FromObjectsAndKeys( new NSObject[]{newView, NSViewAnimation.FadeOutEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});
				NSDictionary fadeIn = NSDictionary.FromObjectsAndKeys( new NSObject[]{newView, NSViewAnimation.FadeInEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});

				NSViewAnimation animation = new NSViewAnimation(new NSDictionary[]{oldViewFadeOut});
				animation.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation.AnimationCurve = NSAnimationCurve.Linear;
				animation.Duration = 0.1;
				animation.StartAnimation();

				NSViewAnimation animation2 = new NSViewAnimation(new NSDictionary[]{newViewFadeOut});
				animation2.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation2.Duration = 0.0;
				animation2.StartAnimation();

				box.ContentView = newView;

				NSViewAnimation animation3 = new NSViewAnimation(new NSDictionary[]{windowResize});
				animation3.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation3.AnimationCurve = NSAnimationCurve.EaseInOut;
				animation3.Duration = 0.2;
				animation3.StartAnimation();


				NSViewAnimation animation4 = new NSViewAnimation(new NSDictionary[]{fadeIn});
				animation4.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation4.AnimationCurve = NSAnimationCurve.Linear;
				animation4.Duration = 0.1;
				animation4.StartAnimation();
			});
		}
		#endregion
	}
}

