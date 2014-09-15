using System;

namespace GeoQuiz
{
	public class TrueFalse {

		private int mQuestion;
		public int Question {
			get {return mQuestion;}
			set {mQuestion = value;}
		}

		private bool mTrueQuestion;
		public bool TrueQuestion {
			get {return mTrueQuestion;}
			set {mTrueQuestion = value;}
		}

		public bool DidCheat {get; set;}

		public TrueFalse(int question, bool trueQuestion)
		{
			mQuestion = question;
			mTrueQuestion = trueQuestion;
			DidCheat = false;
		}
	}
}

