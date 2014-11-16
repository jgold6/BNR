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
			canvas.DrawText("How about now?", 10, canvas.Height/2, mTextPaint);

			foreach (Box box in mBoxes) {
				float left = Math.Min(box.Origin.X, box.Current.X);
				float right = Math.Max(box.Origin.X, box.Current.X);
				float top = Math.Min(box.Origin.Y, box.Current.Y);
				float bottom = Math.Max(box.Origin.Y, box.Current.Y);

				canvas.DrawRect(left, top, right, bottom, mBoxPaint);
			}

		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			System.Drawing.PointF curr = new System.Drawing.PointF(e.GetX(), e.GetY());

			Console.Write("[{0}] Received event at x={1}, y={2}: ", TAG, curr.X, curr.Y);

			switch (e.Action) {
				case MotionEventActions.Down:
					Console.WriteLine("Down" );
					// Reset drawing state
					mCurrentBox = new Box(curr);
					mBoxes.Add(mCurrentBox);
					break;
				case MotionEventActions.Move:
					Console.WriteLine("Move" );
					if (mCurrentBox != null) {
						mCurrentBox.Current = curr;
						Invalidate();
					}
					break;
				case MotionEventActions.Up:
					Console.WriteLine("Up" );
					mCurrentBox = null;
					break;
				case MotionEventActions.Cancel:
					Console.WriteLine("Cancel" );
					mCurrentBox = null;
					break;
			}

			return true;
		}

		protected override Android.OS.IParcelable OnSaveInstanceState()
		{
			IParcelable superState = base.OnSaveInstanceState();
			Bundle bundle = new Bundle();
			bundle.PutParcelable("parcelable", superState);
			bundle.PutString("json", JsonConvert.SerializeObject(mBoxes));
			return bundle;
		}

		protected override void OnRestoreInstanceState(IParcelable state)
		{
			Bundle bundle = (Bundle)state;
			IParcelable parcelable = (IParcelable)bundle.GetParcelable("parcelable");
			mBoxes = JsonConvert.DeserializeObject<List<Box>>(bundle.GetString("json"));
			base.OnRestoreInstanceState(parcelable);
		}
    }

	public class SavedState : Android.Views.View.BaseSavedState
	{
		string jsonString;
		public SavedState(IParcelable superState, string jString) : base(superState)
		{
			jsonString = jString;
		}

		public string JsonString {get {return jsonString;}}

		public override void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
		{
			base.WriteToParcel(dest, flags);
			dest.WriteString(jsonString);
		}
	}
}

