using System;

namespace TypingTutor
{
    public static class MyExtensions
    {
		public static string GetFirstLetter(this string str)
		{
			return str.Substring(0,1);
		}
    }
}

