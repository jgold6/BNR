using System;
using Foundation;
using AppKit;
using System.Runtime.InteropServices;

namespace TypingTutor
{
	// Used to convert string to color and color to string
	[Register("ColorFormatter")]
    public class ColorFormatter : NSFormatter
    {
		#region - Member variables
		NSColorList colorList;
		nint oldColorStringLength;
		#endregion

		#region - Constructors
        public ColorFormatter()
        {
			Initialize();
        }

		public ColorFormatter(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		void Initialize()
		{
//			foreach (NSColorList cl in NSColorList.AvailableColorLists) {
//				Console.WriteLine("Color List: {0}", cl.Name);
//			}
			// Possible color list names - "Apple", "Crayons", "System" (causes crash), and "Web Safe Colors" (named by hex values);
			colorList = NSColorList.ColorListNamed("Crayons");
//			foreach (string c in colorList.AllKeys()) {
//				Console.WriteLine("Color: {0}", c);
//			}
		}
		#endregion

		#region - overrides
		// Gets the string for the text field from the object passed in.
		public override string StringFor(NSObject value)
		{
			// Not a color?
			if (value.GetType() != typeof(NSColor)) {
				return null;
			}

			// Convert to an RGB color space
			NSColor color = ((NSColor)value).UsingColorSpace(NSColorSpace.CalibratedRGB);

			// Get components as floats between 0 and 1
			nfloat red, green, blue, alpha;
			color.GetRgba(out red, out green, out blue, out alpha);

			// Initialize the distance to something large
			double minDistance = 3.0f;
			string closestKey = "";

			// Find the closest color
			foreach (string key in colorList.AllKeys()) {
				NSColor c = colorList.ColorWithKey(key);
				nfloat r, g, b, a;
				c.GetRgba(out r, out g, out b, out a);

				// How far apart are color and c?
				double distance = (Math.Pow(red - r, 2) + Math.Pow(green - g, 2) + Math.Pow(blue - b, 2));
				// Is this the closest yet?
				if (distance < minDistance) {
					minDistance = distance;
					closestKey = key;
				}

			}
			return closestKey;
		}

		[Export("attributedStringForObjectValue:withDefaultAttributes:")]
		public NSAttributedString AttributedStringFor(NSObject value, NSDictionary attributes)
		{
			string match = StringFor(value);
			if (match == null) {
				return null;
			}
			NSMutableDictionary attDict = (NSMutableDictionary)attributes.MutableCopy();
			attDict.LowlevelSetObject(value, NSAttributedString.ForegroundColorAttributeName.Handle);
			NSAttributedString atString = new NSAttributedString(match, attDict);
			return atString;
		}

		// Should be an override but not implemented in Xamarin.Mac
		// TODO: File a bug report
		// Gets the object for the text field from the text field string passed in.
		// Return true if the object is found, false if not. 
		[Export("getObjectValue:forString:errorDescription:")]
		public bool ObjectValue(out NSObject obj, NSString str, IntPtr errorDescription)
		{
			string errorDescriptionString = String.Format("\"{0}\" does not match any color", str);
			obj = null;
			// Look up the color for the string
			string matchingKey = FirstColorKeyForPartialString(str.ToString());
			if (matchingKey != null) {
				obj = colorList.ColorWithKey(matchingKey);
				return true;
			}
			else {
				if (errorDescription != IntPtr.Zero) {
					NSString errorDescriptionObj = new NSString (errorDescriptionString);
					Marshal.WriteIntPtr(errorDescription, errorDescriptionObj.Handle);
				}
				return false;
			}
		}

//		[Export("isPartialStringValid:newEditingString:errorDescription:")]
//		public bool IsPartialStringValid(NSString partial, ref NSString newString, ref NSString error)
//		{
//			// Zero length strings are OK
//			if (partial.Length == 0) {
//				return true;
//			}
//			string match = FirstColorKeyForPartialString(partial);
//			if (match != null) {
//				return true;
//			}
//			else {
//				if (error != null) {
//					error = new NSString("No Such Color");
//				}
//				return false;
//			}
//		}
		[Export("isPartialStringValid:proposedSelectedRange:originalString:originalSelectedRange:errorDescription:")]
		public bool IsPartialStringValid(ref NSString partial, ref NSRange selPtr, NSString origString, ref NSRange origSel, IntPtr error)
		{
			// Zero length strings are OK
			if (partial.Length == 0) {
				return true;
			}
			string match = FirstColorKeyForPartialString(partial);
			// No color match?
			if (match == null) {
				return false;
			}

			// If no letters were added, it is a delete
//			Console.WriteLine("orig string: {0}, partial string: {1}", origString, partial);
			if (oldColorStringLength == partial.Length) {
				oldColorStringLength--;
				selPtr.Location = partial.Length -1;
				selPtr.Length = match.Length - selPtr.Location;
				partial = (NSString)match;
				return false;
			}
			oldColorStringLength = partial.Length;
			// If the partial string is shorter than the match,
			// provide the match and set the selection
			if (match.Length != partial.Length) {
				selPtr.Location = partial.Length;
				selPtr.Length = match.Length - selPtr.Location;
				partial = (NSString)match;
				return false;
			}
			return true;
		}
		#endregion

		#region - Methods
		string FirstColorKeyForPartialString(string str)
		{
			// Is the key zero length?
			if (str.Length == 0) {
				return null;
			}

			// Loop throught the color list
			foreach (string key in colorList.AllKeys()) {
				int index = key.IndexOf(str, StringComparison.OrdinalIgnoreCase);

				if (index == 0) {
					return key;
				}
			}

			// No Match found
			return null;
		}
		#endregion
    }
}

