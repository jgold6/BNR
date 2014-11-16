using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RunTracker
{
	[Activity(Label = "RunTracker", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class RunActivity : SingleFragmentActivity
    {
		protected override Fragment CreateFragment()
		{
			return new RunFragment();
		}
    }
}


