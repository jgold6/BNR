using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace GeoQuiz
{
    [Activity(Label = "GeoQuiz", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class QuizActivity : Activity
    {
		private const string TAG = "QuizActivity";
		private const string KEY_INDEX = "index";

		private Button mTrueButton;
		private Button mFalseButton;
		private ImageButton mNextButton;
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

		private void updateQuestion() {
			int question = mQuestionBank[mCurrentIndex].Question;
			mQuestionTextView.SetText(question);
		}

		private void checkAnswer(bool userPressedTrue) {
			bool answerIsTrue = mQuestionBank[mCurrentIndex].TrueQuestion;

			int messageResId = 0;

			if (userPressedTrue == answerIsTrue) {
				messageResId = Resource.String.correct_toast;
			} else {
				messageResId = Resource.String.incorrect_toast; 
			}

			Toast.MakeText(this, messageResId, ToastLength.Short).Show();
		}

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

		protected override void OnStart() {
			base.OnStart();
			Console.WriteLine("onStart() called");
		}

		protected override void OnResume() {
			base.OnResume();
			Console.WriteLine("onResume() called");
		}

		
		protected override void OnPause() {
			base.OnPause();
			Console.WriteLine("onPause() called");
		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState) {	
			base.OnRestoreInstanceState(savedInstanceState);
		}

		protected override void OnSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			Console.WriteLine("onSaveInstanceState() called");
			outState.PutInt(KEY_INDEX, mCurrentIndex);
		}

		protected override void OnStop() {
			base.OnStop();
			Console.WriteLine("onStop() called");
		}

		protected override void OnDestroy() {
			base.OnDestroy();
			Console.WriteLine("onDestroy() called");
		}
    }
}


