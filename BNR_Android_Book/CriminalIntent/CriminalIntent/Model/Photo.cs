using System;

namespace CriminalIntent
{
    public class Photo
    {
		public string Filename {get; set;}
		public int Orientation {get; set;}

		public Photo(string filename)
        {
			Filename = filename;
        }

		public float GetRotation() {

			float rotation = 0.0f;
			switch (Orientation) {
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

