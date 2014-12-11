using System;
using Android.Support.V4.App;
using Android.Util;

namespace CriminalIntent
{
    public abstract class SmartFragmentStatePagerAdapter : FragmentStatePagerAdapter
    {
		SparseArray<Fragment> registeredFragments = new SparseArray<Fragment>();

		public SmartFragmentStatePagerAdapter(FragmentManager fragmentManager) : base(fragmentManager)
		{

		}

		public override Java.Lang.Object InstantiateItem(Android.Views.ViewGroup container, int position)
		{
			Fragment fragment = (Fragment)base.InstantiateItem(container, position);
			registeredFragments.Put(position, fragment);
			return fragment;
		}

		public override void DestroyItem(Android.Views.ViewGroup container, int position, Java.Lang.Object obj)
		{
			registeredFragments.Remove(position);
			base.DestroyItem(container, position, obj);
		}

		public Fragment GetRegisteredFragment(int position)
		{
			return registeredFragments.Get(position);
		}


    }
}

