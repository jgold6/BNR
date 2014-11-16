using System;
using Android.App;
using Android.Widget;
using Android.Views;

namespace RunTracker
{
    public class RunFragment : Fragment
    {
		Button mStartButton, mStopButton;
		TextView mStartedTextView, mLatitudeTextView, mLongitudeTextView, mAltitudeTextView, mDurationTextView;

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.fragment_run, container, false);

			mStartedTextView = view.FindViewById<TextView>(Resource.Id.run_startedTextView);
			mLatitudeTextView = view.FindViewById<TextView>(Resource.Id.run_latitudeTextView);
			mLongitudeTextView = view.FindViewById<TextView>(Resource.Id.run_longitudeTextView);
			mAltitudeTextView = view.FindViewById<TextView>(Resource.Id.run_altitudeTextView);
			mDurationTextView = view.FindViewById<TextView>(Resource.Id.run_durationTextView);

			mStartButton = view.FindViewById<Button>(Resource.Id.run_startButton);
			mStopButton = view.FindViewById<Button>(Resource.Id.run_stopButton);

			return view;
		}
    }
}

