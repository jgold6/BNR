using System;
using Android.App;
using Android.Views;

namespace DragAndDraw
{
    public class DragAndDrawFragment : Fragment
    {
		public static readonly string TAG = "DragAndDrawFragment";

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_drag_and_draw, container, false);

			return v;
		}
    }
}

