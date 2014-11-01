
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
	public class NerdSwitcherFragment : ListFragment
    {
		private static readonly string TAG = "NerdSwitcherFragment";

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

		public override void OnResume()
		{
			base.OnResume();

			ActivityManager am = (ActivityManager)Activity.GetSystemService(Activity.ActivityService);
			List<ActivityManager.RunningTaskInfo> runningTasks = am.GetRunningTasks(100).ToList();

			System.Diagnostics.Debug.WriteLine("[{0}] I've found {1} running tasks", TAG, runningTasks.Count);

			foreach (ActivityManager.RunningTaskInfo rt in runningTasks)
				System.Diagnostics.Debug.WriteLine("[{0}] Task TopActivity ClassName: {1}", TAG, rt.TopActivity.ClassName);

			SwitcherArrayAdapter adapter = new SwitcherArrayAdapter(Activity, Android.Resource.Layout.ActivityListItem, runningTasks);

			this.ListAdapter = adapter;
		}

		public override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);

			ActivityManager.RunningTaskInfo runningTaskInfo = (ActivityManager.RunningTaskInfo)l.Adapter.GetItem(position);

			if (runningTaskInfo == null) return;

			ActivityManager am = (ActivityManager)Activity.GetSystemService(Activity.ActivityService);
			am.MoveTaskToFront(runningTaskInfo.Id, MoveTaskFlags.WithHome);
		}
    }

	public class SwitcherArrayAdapter : ArrayAdapter<ActivityManager.RunningTaskInfo> 
	{
		Activity context;
		public SwitcherArrayAdapter(Context context, int resID, List<ActivityManager.RunningTaskInfo> activities) : base(context, resID, activities)
		{
			this.context = (Activity)context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View v = convertView;
			if (v == null)
				v = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
	
			ActivityManager.RunningTaskInfo rt = GetItem(position);
			PackageManager pm = NerdSwitcherActivity.Context.PackageManager;
		
			v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = rt.TopActivity.ClassName;
			v.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(rt.Thumbnail);

			return v;
		}
	}
}

