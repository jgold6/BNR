using System;
using Android.Media;

namespace CriminalIntent
{
    public class Photo
    {
		public string Filename {get; private set;}
		private int mOrientation;

		public Photo(string filename)
        {
			Filename = filename;
			// Get and set picture orienation
			ExifInterface exif = new ExifInterface(Filename);
			mOrientation = exif.GetAttributeInt(ExifInterface.TagOrientation, (int)PhotoOrienation.Normal);
        }

		public float GetRotation() {
			float rotation = 0.0f;
			switch (mOrientation) {
				case (int)PhotoOrienation.Rotate90:
					rotation = 90.0f;
					break;
				case (int)PhotoOrienation.Rotate180:
					rotation = 180.0f;
					break;
				case (int)PhotoOrienation.Rotate270:
					rotation = 270.0f;
					break;
				default:
					break;
			}
			return rotation;
		}
    }
}

