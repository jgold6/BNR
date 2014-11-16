using System;
using System.Drawing;

namespace DragAndDraw
{
    public class Box
    {
		PointF mOrigin;
		PointF mCurrent;
		int mPointerId;
		float mRotation;

		public Box(PointF origin, int pointerId)
        {
			mOrigin = mCurrent = origin;
			mPointerId = pointerId;
			mRotation = 0;
        }

		public PointF Origin {
			get {return mOrigin;}
		}

		public PointF Current {
			get {return mCurrent;} 
			set {mCurrent = value;}
		}

		public int PointerId {
			get {return mPointerId;}
		}

		public float Rotation {
			get {return mRotation;}
			set {mRotation = value%360;}
		}
    }
}

