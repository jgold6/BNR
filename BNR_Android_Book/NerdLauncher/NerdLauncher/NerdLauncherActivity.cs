using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace NerdLauncher
{
	[Activity(Label = "NerdLauncher", Icon = "@drawable/icon", Theme="@android:style/Theme.Holo.Light.DarkActionBar")]
	// Allows this activity to replace the home screen on the Android device
	//[IntentFilter(new[]{Intent.ActionMain}, Categories = new[] {Intent.CategoryHome, Intent.CategoryDefault})]
	public class NerdLauncherActivity : SingleFragmentActivity
    {
		public static NerdLauncherActivity Context {get; private set;}

		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			NerdLauncherActivity.Context = this;

			return new NerdLauncherFragment();
		}

		protected override int GetLayoutResId()
		{
			return Resource.Layout.activity_fragment;
		}
		#endregion

		#region - Lifecycle
		#endregion

		#region - NerdLauncherFragment ICallbacks
		#endregion
    }
}


