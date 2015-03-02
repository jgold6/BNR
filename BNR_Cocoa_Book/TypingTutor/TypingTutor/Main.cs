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
				Console.WriteLine("[NSApplication.Init] Exception: {0}", ex.Message);
			}
			try
			{
				NSApplication.Main(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine("[NSApplication.Main] Exception: {0}", ex.Message);
			}
        }
    }
}
