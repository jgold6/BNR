
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

namespace HelloMoon
{
	public class HelloMoonFragment : Fragment
    {
		Button mPlayButton;
		Button mStopButton;


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_hello_moon, container, false);

			mPlayButton = (Button)v.FindViewById(Resource.Id.hellomoon_playButton);
			mStopButton = (Button)v.FindViewById(Resource.Id.hellomoon_stopButton);

			return v;
		}

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }
    }
}

