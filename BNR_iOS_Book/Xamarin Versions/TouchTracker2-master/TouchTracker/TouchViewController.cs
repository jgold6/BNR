using System;
using MonoTouch.UIKit;

namespace TouchTracker
{
	public class TouchViewController : UIViewController
	{
		public TouchViewController() : base()
		{
			LineStore.loadItemsFromArchive();
		}

		public override void LoadView()
		{
			TouchDrawView drawView = new TouchDrawView(UIScreen.MainScreen.Bounds);
			this.View = drawView;
		}
	}
}

