using System;
using Android.OS;
using Android.App;
using Mono.Data.Sqlite;
using System.Runtime.InteropServices;

namespace RunTracker
{
    public abstract class SingleFragmentActivity : Activity
    {
		// Allows for multi-threaded access to Sqlite
		[DllImport("libsqlite.so")]
		internal static extern int sqlite3_shutdown();

		[DllImport("libsqlite.so")]
		internal static extern int sqlite3_initialize();


		protected abstract Fragment CreateFragment();

		protected virtual int GetLayoutResId()
		{
			return Resource.Layout.activity_fragment;
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			sqlite3_shutdown();
			SqliteConnection.SetConfig(SQLiteConfig.Serialized);
			sqlite3_initialize();

			//RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
			base.OnCreate(savedInstanceState);
			SetContentView(GetLayoutResId());

			Fragment fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment == null) {
				fragment = CreateFragment();
				FragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
			}
		}
    }
}

