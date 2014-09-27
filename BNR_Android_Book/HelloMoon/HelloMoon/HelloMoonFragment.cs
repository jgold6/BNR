
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace HelloMoon
{
	public class HelloMoonFragment : Fragment
    {
		Button mPlayButton;
		Button mStopButton;
		Button mPauseButton;

//		Button vPlayButton;
//		Button vStopButton;
//		Button vPauseButton;

		AudioPlayer mPlayer = new AudioPlayer();
		VideoView mVideoView;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_hello_moon, container, false);

			mPlayButton = (Button)v.FindViewById(Resource.Id.hellomoon_playButton);
			mPlayButton.Click += (object sender, EventArgs e) => {
				mPlayer.Play(Activity);
			};

			mStopButton = (Button)v.FindViewById(Resource.Id.hellomoon_stopButton);
			mStopButton.Click += (object sender, EventArgs e) => {
				mPlayer.Stop();
			};

			mPauseButton = (Button)v.FindViewById(Resource.Id.hellomoon_pauseButton);
			mPauseButton.Click += (object sender, EventArgs e) => {
				mPlayer.Pause();
			};

//			string fileName = "http://johnnygold.com/PigsInAPolka1943.mp4"; //Works from web
			string fileName = "android.resource://" + Activity.PackageName + "/" + Resource.Raw.apollo_17_strollnexus; // Now works from device.

			Activity.Window.SetFormat(Android.Graphics.Format.Translucent);
			mVideoView = (VideoView)v.FindViewById(Resource.Id.videoView);
			MediaController controller = new MediaController(Activity);
			mVideoView.SetMediaController(controller);
			mVideoView.RequestFocus();
			Android.Net.Uri uri = Android.Net.Uri.Parse(fileName);
			mVideoView.SetVideoURI(uri);

//			mVideoView.Start();

			// Not needed with MediaController
//			vPlayButton = (Button)v.FindViewById(Resource.Id.hellomoon_vPlayButton);
//			vPlayButton.Click += (object sender, EventArgs e) => {
//				mVideoView.Start();
//				vPauseButton.Enabled = true;
//			};
//
//			vStopButton = (Button)v.FindViewById(Resource.Id.hellomoon_vStopButton);
//			vStopButton.Click += (object sender, EventArgs e) => {
//				mVideoView.StopPlayback();
//				vPauseButton.Enabled = false;
//				mVideoView.SetVideoURI(Android.Net.Uri.Parse(fileName));
//			};
//
//			vPauseButton = (Button)v.FindViewById(Resource.Id.hellomoon_vPauseButton);
//			vPauseButton.Click += (object sender, EventArgs e) => {
//				vPauseButton.Enabled = false;
//				mVideoView.Pause();
//			};

			return v;
		}

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
        }

		public override void OnDestroy()
		{
			base.OnDestroy();
			mPlayer.Stop();
		}
    }
}

