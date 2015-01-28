using System;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;
using System.Collections.Generic;
using Android.OS;
using Android.App;
using Newtonsoft.Json;

namespace DragAndDraw
{
    public class BoxDrawingView : View
    {
		public static readonly string TAG = "BoxDrawingView";

		Paint mTextPaint;
		Box mCurrentBox;
		List<Box> mBoxes;

		Paint mBoxPaint;
		Paint mBackgroundPaint;

		Box mRotationStart;
		float mInitialRotation;
		int pointer2Index;

		#region - Constructors
		public BoxDrawingView(Context context) : base(context, null)
        {
			init();
        }

		public BoxDrawingView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init();
		}

		public BoxDrawingView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
			init();
		}

		void init()
		{
			mTextPaint = new Paint(PaintFlags.AntiAlias | PaintFlags.FakeBoldText);
			mTextPaint.TextSize = 50;

			mBoxes = new List<Box>();

			// Paint the boxes a nice semi-transparent red
			mBoxPaint = new Paint();
			mBoxPaint.Color = Color.Argb(34, 255, 0, 0);

			// Paint the background off-white
			mBackgroundPaint = new Paint();
			mBackgroundPaint.Color = Color.Argb(255, 248, 239, 224);

		}
		#endregion

		protected override void OnDraw(Android.Graphics.Canvas canvas)
		{
			base.OnDraw(canvas);

			// Fill the background
			canvas.DrawPaint(mBackgroundPaint);

			// Test Text
			canvas.Save();
			var textWidth = mTextPaint.MeasureText("Hello");
			Rect textBounds = new Rect();
			mTextPaint.GetTextBounds("Hello", 0, 1, textBounds);
			canvas.DrawText("Hello", canvas.Width/2-textWidth/2, canvas.Height/2 - textBounds.Height()/2, mTextPaint);

			textWidth = mTextPaint.MeasureText("World");
			textBounds = new Rect();
			mTextPaint.GetTextBounds("World", 0, 1, textBounds);
			mTextPaint.Color = Color.Green;
			canvas.DrawText("World", (canvas.Width/2-textWidth/2) +100, (canvas.Height/2 - textBounds.Height()/2) + 100, mTextPaint);


			canvas.Restore();

			foreach (Box box in mBoxes) {
				float left = Math.Min(box.Origin.X, box.Current.X);
				float right = Math.Max(box.Origin.X, box.Current.X);
				float top = Math.Min(box.Origin.Y, box.Current.Y);
				float bottom = Math.Max(box.Origin.Y, box.Current.Y);
				canvas.Save();
				canvas.Rotate(box.Rotation, (box.Origin.X + box.Current.X)/2, (box.Origin.Y + box.Current.Y)/2 );
				canvas.DrawRect(left, top, right, bottom, mBoxPaint);
				canvas.Restore();
			}
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			// Get current position of pointer at index 0.
			// This will be the first pointer down and the last pointer up even if not the same
			System.Drawing.PointF curr = new System.Drawing.PointF(e.GetX(), e.GetY());

			switch (e.Action) {
				case MotionEventActions.PointerDown:
					pointer2Index = 1;
					break;
				case MotionEventActions.Down:
					// Set the current box and add it to the List<Box> mBoxes
					if (mCurrentBox == null) {
						mCurrentBox = new Box(curr, e.GetPointerId(0));
						mBoxes.Add(mCurrentBox);
					}
					break;
				case MotionEventActions.Pointer2Down:
					// Handle 2nd touch. Set the start point of the rotation
					if (mRotationStart == null) {
						// Get coordinates of pointer 2
						MotionEvent.PointerCoords pCoords = new MotionEvent.PointerCoords();
						e.GetPointerCoords(1, pCoords);
						// Set the starting coordinates for the rotation
						mRotationStart = new Box(new System.Drawing.PointF(pCoords.X, pCoords.Y), e.GetPointerId(1));
						mInitialRotation = mCurrentBox.Rotation;
						pointer2Index = 1;
					}
					break;
				case MotionEventActions.Move:
					// Handle first pointer move, set end point for rectangle
					if (mCurrentBox != null && mCurrentBox.PointerId == e.GetPointerId(0)) {
						mCurrentBox.Current = curr;
					}
					// Handle second pointer move, set rotation amount
					if (mRotationStart != null && mRotationStart.PointerId == e.GetPointerId(pointer2Index)) {
						// Get coordinates of pointer 2
						MotionEvent.PointerCoords pCoords = new MotionEvent.PointerCoords();
						e.GetPointerCoords(pointer2Index, pCoords);
						// Set the rotation of the box to the difference between the origin of mRotation and the current position of pointer 2
						mCurrentBox.Rotation = mInitialRotation + pCoords.Y - mRotationStart.Origin.Y;
					}
					Invalidate();
					break;
				case MotionEventActions.Pointer2Up:
					mRotationStart = null;
					break;
				case MotionEventActions.PointerUp:
					pointer2Index = 0;
					break;
				case MotionEventActions.Up:
					mCurrentBox = null;
					mRotationStart = null;
					break;
				case MotionEventActions.Cancel:
					mCurrentBox = null;
					mRotationStart = null;
					break;
			}

			return true;
		}

		protected override Android.OS.IParcelable OnSaveInstanceState()
		{
			// Get the state of the view
			IParcelable superState = base.OnSaveInstanceState();
			Bundle bundle = new Bundle();
			// put the state in the bundle
			bundle.PutParcelable("parcelable", superState);
			// serialize mBoxes to JSON and put that in the bundle
			bundle.PutString("json", JsonConvert.SerializeObject(mBoxes));
			return bundle;
		}

		protected override void OnRestoreInstanceState(IParcelable state)
		{
			Bundle bundle = (Bundle)state;
			// Get the IParcelable object
			IParcelable parcelable = (IParcelable)bundle.GetParcelable("parcelable");
			// Deserialize the JSON string from the bundle into mBoxes
			mBoxes = JsonConvert.DeserializeObject<List<Box>>(bundle.GetString("json"));
			// Restore the View state from the IParcelable state object
			base.OnRestoreInstanceState(parcelable);
		}
    }
}

