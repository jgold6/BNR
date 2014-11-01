using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Runtime;

namespace RemoteControl
{
	public class RemoteControlFragment : Fragment, View.IOnClickListener
    {
		private TextView mSelectedTextView;
		private TextView mWorkingTextView;

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_remote_control, container, false);

			mSelectedTextView = v.FindViewById<TextView>(Resource.Id.fragment_remote_control_selectedTextView);
			mWorkingTextView = v.FindViewById<TextView>(Resource.Id.fragment_remote_control_workingTextView);

			Button zeroButton = v.FindViewById<Button>(Resource.Id.fragment_remote_control_zeroButton);
			zeroButton.SetOnClickListener(this);

			Button oneButton = v.FindViewById<Button>(Resource.Id.fragment_remote_control_oneButton);
			oneButton.SetOnClickListener(this);

			Button enterButton = v.FindViewById<Button>(Resource.Id.fragment_remote_control_enterButton);
			enterButton.Click += (object sender, EventArgs e) => {
				Console.WriteLine("Enter Button Clicked");
				string working = mWorkingTextView.Text;
				if (working.Length > 0) {
					mSelectedTextView.Text = working;
				}
				mWorkingTextView.Text = "0";
			};

			return v;
		}

		public void OnClick(View v)
		{
			Console.WriteLine("Number Button Clicked");

			TextView textView = (TextView)v;
			string working = mWorkingTextView.Text;
			string text = textView.Text;
			if (working.Equals("0")) {
				mWorkingTextView.Text = text;
			}
			else {
				mWorkingTextView.Text = working + text;
			}

		}
    }
}

