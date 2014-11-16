using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DragAndDraw
{
	[Activity(Label = "DragAndDraw", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class DragAndDrawActitivy : SingleFragmentActivity
    {
		public static readonly string TAG = "DragAndDrawActitivy";

		protected override Fragment CreateFragment()
		{
			return new DragAndDrawFragment();
		}
        
    }
}


