#region - Using statements
using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
#endregion

namespace GeoQuiz
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class QuizActivity : Activity
    {
		#region - Enums and Constants
		private const string TAG = "QuizActivity";
		private const string KEY_INDEX = "index";
		private const string KEY_IS_CHEATER = "shown";
		enum ResponseCodes {CheatActivity};
		#endregion

		#region - member variables
		private Button mTrueButton;
		private Button mFalseButton;
		private ImageButton mNextButton;
		private Button mCheatButton;
		private ImageButton mPrevButton;
		private TextView mQuestionTextView;

		TrueFalse[] mQuestionBank = new TrueFalse[] {
			new TrueFalse(Resource.String.question_oceans, true),
			new TrueFalse(Resource.String.question_mideast, false),
			new TrueFalse(Resource.String.question_africa, false),
			new TrueFalse(Resource.String.question_americas, true),
			new TrueFalse(Resource.String.question_asia, true),
		};

		int mCurrentIndex = 0;
		#endregion

		#region - Private methods
		private void updateQuestion() {
			int question = mQuestionBank[mCurrentIndex].Question;
			mQuestionTextView.SetText(question);
		}

		private void checkAnswer(bool userPressedTrue) {
			bool answerIsTrue = mQuestionBank[mCurrentIndex].TrueQuestion;

			int messageResId = 0;

			if (mQuestionBank[mCurrentIndex].DidCheat) {
				messageResId = Resource.String.judgment_toast;
			} else {
				if (userPressedTrue == answerIsTrue) {
					messageResId = Resource.String.correct_toast;
				} else {
					messageResId = Resource.String.incorrect_toast; 
				}
			}

			Toast.MakeText(this, messageResId, ToastLength.Short).Show();
			if (mQuestionBank[mCurrentIndex].DidCheat)
				Toast.MakeText(this, "If you forgot, the answer is " + mQuestionBank[mCurrentIndex].TrueQuestion, ToastLength.Short).Show();
		}
		#endregion

		#region - LifeCycle Methods
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_quiz);

			Console.WriteLine("onCreate(Bundle) called");

			mQuestionTextView = (TextView)FindViewById(Resource.Id.question_textView);
			mQuestionTextView.Click += (object sender, EventArgs e) => {
				mCurrentIndex = (mCurrentIndex +1) % mQuestionBank.Length;
				updateQuestion();
			};

			mTrueButton = (Button)FindViewById(Resource.Id.true_button);
			mTrueButton.Click += (object sender, EventArgs e) => {
				checkAnswer(true);
			};

			mFalseButton = (Button)FindViewById(Resource.Id.false_button);
			mFalseButton.Click += (object sender, EventArgs e) => {
				checkAnswer(false);
			};

			mNextButton = (ImageButton)FindViewById(Resource.Id.next_button);
			mNextButton.Click += (object sender, EventArgs e) => {
				mCurrentIndex = (mCurrentIndex +1) % mQuestionBank.Length;
				updateQuestion();
			};

			mCheatButton = (Button)FindViewById(Resource.Id.cheat_button);
			mCheatButton.Click += (object sender, EventArgs e) => {
				if (mQuestionBank[mCurrentIndex].DidCheat == true) {
					Toast.MakeText(this, Resource.String.already_cheated, ToastLength.Short).Show();
					Toast.MakeText(this, "If you forgot, the answer is " + mQuestionBank[mCurrentIndex].TrueQuestion, ToastLength.Short).Show();
					return;
				}
				// Start CheatActivity
				var intent = new Intent(this, typeof(CheatActivity));
				intent.PutExtra(CheatActivity.EXTRA_ANSWER_IS_TRUE, mQuestionBank[mCurrentIndex].TrueQuestion);
				StartActivityForResult(intent, (int)ResponseCodes.CheatActivity);
			};

			mPrevButton = (ImageButton)FindViewById(Resource.Id.prev_button);
			mPrevButton.Click += (object sender, EventArgs e) => {
				mCurrentIndex = (mCurrentIndex -1) % mQuestionBank.Length;

				if (mCurrentIndex < 0){
					mCurrentIndex = mQuestionBank.Length - 1;
				}
				updateQuestion();
			};

			if (savedInstanceState != null) {
				mCurrentIndex = savedInstanceState.GetInt(KEY_INDEX, 0);
				for (int i = 0; i < mQuestionBank.Length; i++) {
					mQuestionBank[i].DidCheat = savedInstanceState.GetBoolean(KEY_IS_CHEATER + i, false);
				}
			}

			updateQuestion();
		}

		public override bool OnCreateOptionsMenu(IMenu menu) {
			// Inflate the menu; this adds items to the action bar if it is present.
			MenuInflater.Inflate(Resource.Menu.activity_quiz, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			// Handle action bar item clicks here. The action bar will
			// automatically handle clicks on the Home/Up button, so long
			// as you specify a parent activity in AndroidManifest.xml.
			int id = item.ItemId;
			if (id == Resource.Id.menu_settings) {
				Console.WriteLine("Settings called");
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			Console.WriteLine("OnActivityResult(...) called");
			if (data == null)
				return;
			if (resultCode == Result.Ok) {
				mQuestionBank[mCurrentIndex].DidCheat = data.GetBooleanExtra(CheatActivity.EXTRA_ANSWER_SHOWN, false);
			}
		}

		protected override void OnStart() {
			base.OnStart();
			Console.WriteLine("onStart() called");
		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState) {	
			base.OnRestoreInstanceState(savedInstanceState);
			Console.WriteLine("onRestoreInstanceState() called");
		}

		protected override void OnResume() {
			base.OnResume();
			Console.WriteLine("onResume() called");
		}

		protected override void OnPause() {
			base.OnPause();
			Console.WriteLine("onPause() called");
		}

		protected override void OnSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			Console.WriteLine("onSaveInstanceState() called");
			outState.PutInt(KEY_INDEX, mCurrentIndex);
			for (int i = 0; i < mQuestionBank.Length; i++) {
				outState.PutBoolean(KEY_IS_CHEATER + i, mQuestionBank[i].DidCheat);
			}
		}

		protected override void OnStop() {
			base.OnStop();
			Console.WriteLine("onStop() called");
		}

		protected override void OnDestroy() {
			base.OnDestroy();
			Console.WriteLine("onDestroy() called");
		}
		#endregion
    }
}


