using System;

using AppKit;

namespace TypingTutor
{
    static class MainClass
    {
        static void Main(string[] args)
        {
			try
			{
				NSApplication.Init();
			}
			catch (Exception ex)
			{
				Console.WriteLine("[NSApplication.Init] Exception: {0}\n{1}", ex.Message, ex.StackTrace);
			}
			try
			{
				NSApplication.Main(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine("[NSApplication.Main] Exception: {0}\n{1}", ex.Message, ex.StackTrace);
			}
        }
    }
}
