﻿
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace SpeakLine
{
    public partial class MainWindowController : MonoMac.AppKit.NSWindowController
    {
		NSSpeechSynthesizer speechSynth;

        #region Constructors

        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
			speechSynth = new NSSpeechSynthesizer("com.apple.speech.synthesis.voice.Trinoids");
        }

        #endregion

		partial void btnSpeak (MonoMac.Foundation.NSObject sender)
		{
			string value = textField.StringValue;
			// Is the string 0 length?
			if (value.Length == 0) {
				return;
			}
			speechSynth.StartSpeakingString(value);
		}

		partial void btnStop (MonoMac.Foundation.NSObject sender)
		{
			speechSynth.StopSpeaking(NSSpeechBoundary.hWord);
		}

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }
    }
}

