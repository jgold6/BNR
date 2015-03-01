using Foundation;
using System;

namespace TypingTutor
{

    // Should subclass AppKit.NSView
    [Foundation.Register("BigLetterView")]
    public partial class BigLetterView
    {
		[Outlet("btnBold")]
		public AppKit.NSButton btnBold { get; set; }
		[Outlet("btnItalic")]
		public AppKit.NSButton btnItalic { get; set; }
		[Outlet("btnShadow")]
		public AppKit.NSButton btnShadow { get; set; }
		[Outlet("tutorConroller")]
		public TutorController tutorController { get; set; }


		[Action ("boldChecked:")]
		partial void boldChecked (Foundation.NSObject sender);

		[Action ("italicChecked:")]
		partial void italicChecked (Foundation.NSObject sender);

		[Action ("shadowChecked:")]
		partial void shadowChecked (Foundation.NSObject sender);

		[Action ("cut:")]
		partial void Cut (Foundation.NSObject sender);
		[Action ("copy:")]
		partial void Copy (Foundation.NSObject sender);
		[Action ("paste:")]
		partial void Paste (Foundation.NSObject sender);
    }
}
