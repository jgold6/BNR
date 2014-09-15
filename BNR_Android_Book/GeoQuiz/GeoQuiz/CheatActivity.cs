
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
using Android.Support.V7.App;

namespace GeoQuiz
{
	[Activity(Label = "@string/app_name", Theme="@style/AppTheme")]            
	public class CheatActivity : ActionBarActivity
    {
		#region - Constants
		public readonly static string EXTRA_ANSWER_IS_TRUE = "com.onobytes.geoquiz.answerIsTrue";
		public readonly static string EXTRA_ANSWER_SHOWN = "com.onobytes.geoquiz.answerShown";
		private const string KEY_ANSWER_SHOWN = "shown";
		#endregion

		#region - Member variables
		private bool mAnswerIsTrue;
		private TextView mAnswerTextView;
		private Button mShowAnswer;
		private TextView mVersionTextView;
		private bool mWasAnswerShown;
		#endregion

		#region - Private methods
		private void SetAnswerShownResult(bool isAnswerShown)
		{
			Intent data = new Intent();
			data.PutExtra(EXTRA_ANSWER_SHOWN, isAnswerShown);
			SetResult(Result.Ok, data);
		}
		#endregion

		#region - Private methods
		private void ShowAnswer()
		{
			if (mAnswerIsTrue)
				mAnswerTextView.SetText(Resource.String.true_button);
			else
				mAnswerTextView.SetText(Resource.String.false_button);
			mWasAnswerShown = true;
			SetAnswerShownResult(mWasAnswerShown);
		}
		#endregion

		#region - Lifecycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_cheat);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb) {
				ActionBar.SetSubtitle(Resource.String.test_subject);
			}

			// Create your application here
			mAnswerIsTrue = Intent.GetBooleanExtra(EXTRA_ANSWER_IS_TRUE, false);

			mAnswerTextView = (TextView)FindViewById(Resource.Id.answerTextView);
			mVersionTextView = (TextView)FindViewById(Resource.Id.apiVersion);
			mVersionTextView.SetText(String.Format("API Level {0} {1}", Build.VERSION.Sdk, Build.VERSION.SdkInt.ToString()), TextView.BufferType.Normal);

			// Answer will not be shown until the user presses the button
			mWasAnswerShown = false;
			SetAnswerShownResult(mWasAnswerShown);

			mShowAnswer = (Button)FindViewById(Resource.Id.showAnswerButton);
			mShowAnswer.Click += (object sender, EventArgs e) => {
				ShowAnswer();
			};

			if (savedInstanceState != null) {
				mWasAnswerShown = savedInstanceState.GetBoolean(KEY_ANSWER_SHOWN, false);
				ShowAnswer();
			}
        }

		protected override void OnSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			Console.WriteLine("CheatActivity onSaveInstanceState() called");
			outState.PutBoolean(KEY_ANSWER_SHOWN, mWasAnswerShown);
		}
		#endregion
    }
}

