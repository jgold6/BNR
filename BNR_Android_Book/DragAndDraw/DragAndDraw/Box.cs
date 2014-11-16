using System;
using System.Drawing;

namespace DragAndDraw
{
    public class Box
    {
		PointF mOrigin;
		PointF mCurrent;
		int mPointerId;

		public Box(PointF origin)//, int pointerId)
        {
			mOrigin = mCurrent = origin;
//			mPointerId = pointerId;
        }

		public PointF Origin {
			get {return mOrigin;}
		}

		public PointF Current {
			get {return mCurrent;} 
			set {mCurrent = value;}
		}

//		public int PointerId {
//			get {return mPointerId;}
//		}
    }
}

