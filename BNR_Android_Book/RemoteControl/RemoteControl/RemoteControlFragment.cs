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

			TableLayout tableLayout = v.FindViewById<TableLayout>(Resource.Id.fragment_remote_control_tableLayout);
			int number = 1;
			for (int i = 2; i < tableLayout.ChildCount -1; i++) {
				TableRow row = (TableRow)tableLayout.GetChildAt(i);
				for (int j = 0; j < row.ChildCount; j++) {
					Button button = (Button)row.GetChildAt(j);
					button.Text = number.ToString();
					button.SetOnClickListener(this);
					number++;
				}
			}

			TableRow bottomRow = (TableRow)tableLayout.GetChildAt(tableLayout.ChildCount -1);

			Button deleteButton= (Button)bottomRow.GetChildAt(0);
			deleteButton.Text = "Delete";
			deleteButton.SetTextAppearance(RemoteControlActivity.Context, Resource.Style.RemoteButton_ActionButton);
			deleteButton.Click += (object sender, EventArgs e) => {
				mWorkingTextView.Text = "0";
			};

			Button zeroButton= (Button)bottomRow.GetChildAt(1);
			zeroButton.Text = "0";
			zeroButton.SetOnClickListener(this);

			Button enterButton = (Button)bottomRow.GetChildAt(2);
			enterButton.Text = "Enter";
			enterButton.SetTextAppearance(RemoteControlActivity.Context, Resource.Style.RemoteButton_ActionButton);
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

