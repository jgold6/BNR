
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

namespace GeoQuiz
{
	[Activity(Label = "@string/app_name")]            
    public class CheatActivity : Activity
    {
		public readonly static string EXTRA_ANSWER_IS_TRUE = "com.onobytes.geoquiz.answerIsTrue";
		public readonly static string EXTRA_ANSWER_SHOWN = "com.onobytes.geoquiz.answerShown";

		private bool mAnswerIsTrue;

		private TextView mAnswerTextView;
		private Button mShowAnswer;

		private void SetAnswerShownResult(bool isAnswerShown)
		{
			Intent data = new Intent();
			data.PutExtra(EXTRA_ANSWER_SHOWN, isAnswerShown);
			SetResult(Result.Ok, data);
		}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_cheat);
            
			// Create your application here
			mAnswerIsTrue = Intent.GetBooleanExtra(EXTRA_ANSWER_IS_TRUE, false);

			mAnswerTextView = (TextView)FindViewById(Resource.Id.answerTextView);

			// Answer will not be shown until the user presses the button
			SetAnswerShownResult(false);

			mShowAnswer = (Button)FindViewById(Resource.Id.showAnswerButton);
			mShowAnswer.Click += (object sender, EventArgs e) => {
				if (mAnswerIsTrue)
					mAnswerTextView.SetText(Resource.String.true_button);
				else
					mAnswerTextView.SetText(Resource.String.false_button);

				SetAnswerShownResult(true);
			};
        }
    }
}

