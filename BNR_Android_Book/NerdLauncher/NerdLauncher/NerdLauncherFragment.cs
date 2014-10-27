
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
using Android.Content.PM;

namespace NerdLauncher
{
	public class NerdLauncherFragment : ListFragment
    {
		private static readonly string TAG = "NerdLauncherFragment";

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
			Intent startupIntent = new Intent(Intent.ActionMain);
			startupIntent.AddCategory(Intent.CategoryLauncher);

			PackageManager pm = Activity.PackageManager;
			List<ResolveInfo> activities = pm.QueryIntentActivities(startupIntent, 0).ToList();

			System.Diagnostics.Debug.WriteLine("[{0}] I've found {1} activities", TAG, activities.Count);

			foreach (ResolveInfo ri in activities)
				System.Diagnostics.Debug.WriteLine("[{0}] Activity name: {1}", TAG, ri.LoadLabel(pm));

			activities = activities.OrderBy(x => x.LoadLabel(pm)).ToList();

			foreach (ResolveInfo ri in activities)
				System.Diagnostics.Debug.WriteLine("[{0}] Activity name (Sorted): {1}", TAG, ri.LoadLabel(pm));

			LauncherArrayAdapter adapter = new LauncherArrayAdapter(Activity, Android.Resource.Layout.ActivityListItem, activities);

			this.ListAdapter = adapter;
        }

		public override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);

			ResolveInfo resolveInfo = (ResolveInfo)l.Adapter.GetItem(position);
			ActivityInfo activityInfo = resolveInfo.ActivityInfo;

			if (activityInfo == null) return;

			Intent i = new Intent(Intent.ActionMain);
			i.SetClassName(activityInfo.ApplicationInfo.PackageName, activityInfo.Name);
			i.AddFlags(ActivityFlags.NewTask);

			StartActivity(i);
		}
    }

	public class LauncherArrayAdapter : ArrayAdapter<ResolveInfo> 
	{
		Activity context;
		public LauncherArrayAdapter(Context context, int resID, List<ResolveInfo> activities) : base(context, resID, activities)
		{
			this.context = (Activity)context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View v = convertView;
			if (v == null)
				v = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
	
			ResolveInfo ri = GetItem(position);
			PackageManager pm = NerdLauncherActivity.Context.PackageManager;

			v.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageDrawable(ri.LoadIcon(pm));
			v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = ri.LoadLabel(pm);

			return v;
		}
	}
}

