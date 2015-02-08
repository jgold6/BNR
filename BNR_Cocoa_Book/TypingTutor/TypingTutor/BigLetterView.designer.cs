using Foundation;

namespace TypingTutor
{

    // Should subclass AppKit.NSView
    [Foundation.Register("BigLetterView")]
    public partial class BigLetterView
    {
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
