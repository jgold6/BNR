using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;
using System.Diagnostics;

namespace HypnoTime.UITest
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			// TODO: If the iOS app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.iOS
				.DeviceIdentifier ("1EAF0958-7B01-4B9D-9813-AEF3FA9E42E8")
			// TODO: Update this path to point to your iOS app and uncomment the
			// code if the app is not included in the solution.
			//.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/HypnoTime.UITest.iOS.app")
				.InstalledApp ("com.your-company.HypnoTime")
				.StartApp ();
		}

		[Test]
		public void AppLaunches ()
		{
			app.WaitForElement (c => c.Marked ("What time is it?"));
			app.Tap (c => c.Marked ("Hypnosis"));

			app.WaitForElement (c => c.Class ("UISegmentedControl"));
			app.Tap (c => c.Marked ("Green"));

			app.InvokeUia ("UIATarget.localTarget().shake()");

			Assert.AreEqual (0, 0);

		}
	}
}

