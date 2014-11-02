using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RemoteControl
{
	[Activity(Label = "RemoteControl", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public class RemoteControlActivity : SingleFragmentActivity
    {
		public static RemoteControlActivity Context {get; private set;}

		#region - abstract overrides
        protected override void OnCreate(Bundle bundle)
        {
			RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(bundle);
        }

		protected override Fragment CreateFragment()
		{
			RemoteControlActivity.Context = this;

			return new RemoteControlFragment();
		}
		#endregion
    }
}


