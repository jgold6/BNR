using System;
using MonoMac.Foundation;

namespace RaiseMan
{
    public class DefaultStrings
    {
        private DefaultStrings()
        {
        }

		public static readonly NSString RMTableBgColorKey = new NSString("RMTableBackgroundColor");
		public static readonly NSString RMEmptyDocKey = new NSString("RMEmptyDocumentFlag");
		public static readonly NSString RMColorChangedNotification = new NSString("RMColorChanged");
		public static readonly NSString RMColor = new NSString("RMColor");
    }
}

