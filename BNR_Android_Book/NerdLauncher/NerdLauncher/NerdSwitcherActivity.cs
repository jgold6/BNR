
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NerdLauncher
{
	[Activity(Label = "NerdSwitcherActivity", MainLauncher = true, Icon = "@drawable/icon", Theme="@android:style/Theme.Holo.Light.DarkActionBar")]            
	public class NerdSwitcherActivity : SingleFragmentActivity
    {
		public static NerdSwitcherActivity Context {get; private set;}

		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			NerdSwitcherActivity.Context = this;

			return new NerdSwitcherFragment();
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

