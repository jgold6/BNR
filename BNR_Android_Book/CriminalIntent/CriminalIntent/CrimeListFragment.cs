using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.App;
using Android.Content;
using Android.Graphics;

namespace CriminalIntent
{
    public class CrimeListFragment : Android.Support.V4.App.ListFragment, AbsListView.IMultiChoiceModeListener
    {
		public static List<int> activatedItems;

		#region - member variables
		bool mSubtitleVisible;
		#endregion

		#region - Lifecycle
		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			HasOptionsMenu = true;

			Activity.SetTitle(Resource.String.crimes_title);
//			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
//				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crimes);
				
			CrimeAdapter adapter = new CrimeAdapter(Activity, CrimeLab.GetInstance(CrimeListActivity.context).Crimes);
			this.ListAdapter = adapter;

			RetainInstance = true;
			mSubtitleVisible = false;
			CrimeListFragment.activatedItems = new List<int>();
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// For EmptyView in Code version
//			View v = base.OnCreateView(inflater, container, savedInstanceState);

			// For EmptyView in XML version
			// Inflate from fragment_crimelist, which has the ListView and the EmptyView
			base.OnCreateView(inflater, container, savedInstanceState);
			View v = (View)inflater.Inflate(Resource.Layout.fragment_crimelist, container, false);
			// Get the button in the EmptyView
			Button btnNewCrime = v.FindViewById<Button>(Resource.Id.button_new_crime);
			btnNewCrime.Click += (object sender, EventArgs e) => {
				NewCrime();
			};

			ListView listView = v.FindViewById<ListView>(Android.Resource.Id.List);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb) {
				if (mSubtitleVisible) {
					Activity.ActionBar.SetSubtitle(Resource.String.subtitle);
				}
				// Use contextual action bar on HoneyComb and higher
				listView.ChoiceMode = ChoiceMode.MultipleModal;
				listView.SetMultiChoiceModeListener(this);
			}
			else {
				// Use floating Context menus on Froyo and Gingerbread
				RegisterForContextMenu(listView);
			}

			// Create EmptyView in code
//			TextView emptyView = new TextView(Activity);
//			emptyView.Text = "No Crimes yet. Click to add a crime.";
//			emptyView.TextAlignment = TextAlignment.Center;
//			emptyView.SetTextSize(Android.Util.ComplexUnitType.Sp, 18);
//			emptyView.SetTextColor(Color.Red);
//			emptyView.Click += (object sender, EventArgs e) => {
//				NewCrime();
//			};
//			container.AddView(emptyView);
//			listView.EmptyView = emptyView;

			return v;
		}

		public override void OnPause()
		{
			base.OnPause();
			CrimeLab.GetInstance(Activity).SaveCrimes();
		}

		public override void OnResume()
		{
			base.OnResume();
			((CrimeAdapter)this.ListAdapter).NotifyDataSetChanged();
		}
		#endregion

		#region - overrides
		public override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			Crime c = ((CrimeAdapter)ListAdapter).GetItem(position);

			// Start crime activity
			Intent i = new Intent(Activity,typeof(CrimePagerActivity));
			i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, c.Id);
			StartActivity(i);
		}
			
		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater) {
			// Inflate the menu; this adds items to the action bar if it is present.
			base.OnCreateOptionsMenu(menu, inflater);
			inflater.Inflate(Resource.Menu.fragment_crime_list, menu);
			IMenuItem showSubtitle = menu.FindItem(Resource.Id.menu_item_show_subtitle);
			if (mSubtitleVisible && showSubtitle != null) {
				showSubtitle.SetTitle(Resource.String.hide_subtitle);
			}
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.menu_item_new_crime:
					NewCrime();
					return true;
				case Resource.Id.menu_item_show_subtitle:
					if (Activity.ActionBar.Subtitle == null) {
						Activity.ActionBar.SetSubtitle(Resource.String.subtitle);
						mSubtitleVisible = true;
						item.SetTitle(Resource.String.hide_subtitle);
					}
					else {
						Activity.ActionBar.Subtitle = null;
						mSubtitleVisible = false;
						item.SetTitle(Resource.String.show_subtitle);
					}
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
		{
			Activity.MenuInflater.Inflate(Resource.Menu.crime_list_item_context, menu);
		}

		public override bool OnContextItemSelected(IMenuItem item)
		{
			AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
			int position = info.Position;
			CrimeAdapter adapter = (CrimeAdapter)ListAdapter;
			Crime crime = adapter.GetItem(position);

			switch (item.ItemId) {
				case Resource.Id.menu_item_delete_crime:
					CrimeLab.GetInstance(Activity).DeleteCrime(crime);
					adapter.Remove(crime);
					return true;
			}
			return base.OnContextItemSelected(item);
		}

		public void OnItemCheckedStateChanged(ActionMode mode, int position, long id, bool chkd)
		{
			// Not used
			Console.WriteLine("OnItemCheckedStateChanged {0}, {1}, {2}. {3}", mode, position, id, chkd);

			// Add or remove item from activatedItems list
			if (chkd) {
				activatedItems.Add(position);
			}
			else {
				activatedItems.Remove(position);
			}
			((CrimeAdapter)ListView.Adapter).NotifyDataSetChanged();
		}

		public bool OnCreateActionMode(ActionMode mode, IMenu menu)
		{
			MenuInflater inflater = mode.MenuInflater;
			inflater.Inflate(Resource.Menu.crime_list_item_context, menu);
			return true;
		}

		public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
		{
			// Not used
			return false;
		}

		public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menu_item_delete_crime:
					CrimeAdapter adapter = (CrimeAdapter)ListAdapter;
					CrimeLab crimelab = CrimeLab.GetInstance(Activity);
					for (int i = adapter.Count -1; i >= 0; i--) {
						if (ListView.IsItemChecked(i)) {
							crimelab.DeleteCrime(adapter.GetItem(i));
							adapter.Remove(adapter.GetItem(i));
						}
					}
					mode.Finish();
					adapter.NotifyDataSetChanged();
					return true;
				default:
					return false;
			}
		}

		public void OnDestroyActionMode(ActionMode mode)
		{
			// Clear out selections
			CrimeListFragment.activatedItems.Clear();
			CrimeAdapter adapter = (CrimeAdapter)ListAdapter;
			adapter.NotifyDataSetChanged();
		}

		#endregion

		#region - helper methods
		private void NewCrime()
		{
			Crime crime = new Crime();
			CrimeLab.GetInstance(Activity).AddCrime(crime);
			CrimeAdapter adapter = this.ListAdapter as CrimeAdapter;
			adapter.Add(crime);

			Intent i = new Intent(Activity, typeof(CrimePagerActivity));
			i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, crime.Id);
			StartActivity(i);
		}
		#endregion

		#region - ArrayAdapter inner subclass
		public class CrimeAdapter : ArrayAdapter<Crime>
		{
			Activity context;
			public CrimeAdapter(Activity context, List<Crime> crimes) : base(context, 0, crimes)
			{
				this.context = context;
			}

			public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
			{
				View view = convertView;
				if (view == null) {
					view = context.LayoutInflater.Inflate(Resource.Layout.list_item_crime, null);
				}

				Crime c = GetItem(position);

				TextView titleTextView = (TextView)view.FindViewById(Resource.Id.crime_list_item_titleTextView);
				TextView dateTextView = (TextView)view.FindViewById(Resource.Id.crime_list_item_dateTextView);
				CheckBox solvedCheckBox = (CheckBox)view.FindViewById(Resource.Id.crime_list_item_solvedCheckBox);

				titleTextView.Text = c.Title;
				dateTextView.Text = String.Format("{0}\n{1}", c.Date.ToLongDateString(), c.Date.ToLongTimeString());
				solvedCheckBox.Checked = c.Solved;

				// Trials to get selected items to change color
				// Finally a method that works
				if (CrimeListFragment.activatedItems.Contains(position)) {
					view.SetBackgroundColor(Color.Red);
				}
				else {
					view.SetBackgroundColor(Color.White);
				}

				return view;
			}
				
		}

		#endregion
    }
}

