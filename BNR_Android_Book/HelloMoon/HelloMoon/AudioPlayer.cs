using System;
using Android.Media;
using Android.Content;
using Android.Views;

namespace HelloMoon
{
    public class AudioPlayer
    {
		MediaPlayer mPlayer;

		public void Stop()
		{
			if (mPlayer != null) {
				mPlayer.Release();
				mPlayer = null;
			}
		}

		public void Play(Context c) 
		{
			if (mPlayer != null && !mPlayer.IsPlaying) {
				mPlayer.Start();
				return;
			}
			Stop();

			mPlayer = MediaPlayer.Create(c, Resource.Raw.one_small_step);

			mPlayer.Completion += (object sender, EventArgs e) => {
				Stop();
			};
			mPlayer.Start();
		}

		public void Pause()
		{
			if (mPlayer != null) {
				if (mPlayer.IsPlaying) 
					mPlayer.Pause();
				else
					mPlayer.Start();
			}
		} 

		public bool IsPlayin()
		{
			if (mPlayer != null)
				return mPlayer.IsPlaying;
			else
				return false;
		}
    }
}

