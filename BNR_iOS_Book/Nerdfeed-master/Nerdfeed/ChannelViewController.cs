using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Nerdfeed
{
	public class ChannelViewController :UITableViewController, IListViewControllerDelegate, IUISplitViewControllerDelegate
	{
		RSSChannel channel {get; set;}
		public UIPopoverController popover {get; set;}

		public ChannelViewController() : base(UITableViewStyle.Grouped)
		{
		}

		public ChannelViewController(UITableViewStyle style) : base(style)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.View.BackgroundColor = UIColor.Black;
			if (this.NavigationController != null) {
				this.NavigationController.NavigationBar.TintColor = UIColor.LightGray;
				this.NavigationController.NavigationBar.Translucent = false;
				this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
//				UIView statusBarBackground = new UIView(new RectangleF(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
//				statusBarBackground.BackgroundColor = UIColor.DarkGray;
//				statusBarBackground.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin);
//				this.NavigationController.View.Add(statusBarBackground);
			}
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return 2;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell("UITableViewCell");
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Value2, "UITableViewCell");

			cell.BackgroundColor = UIColor.Black;
			cell.TextLabel.TextColor = UIColor.LightGray;
			cell.DetailTextLabel.TextColor = UIColor.Yellow;
			if (indexPath.Row == 0) {
				// Put the title of the channel in row 0
				cell.TextLabel.Text = "Title";
				cell.DetailTextLabel.Text = channel.title;
			} else {
				// Put the description of the channel in row 1
				cell.TextLabel.Text = "Info";
				cell.DetailTextLabel.Text = channel.description;
			}

			return cell;
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				return true;

			return InterfaceOrientation == UIInterfaceOrientation.Portrait;
		}

		public void listViewControllerHandleObject(ListViewController lvc, object obj)
		{
			// Make sure that we are getting the right object
			if (obj.GetType() != typeof(RSSChannel))
				return;

			channel = obj as RSSChannel;

			this.NavigationItem.Title = "Channel Info";

			this.TableView.ReloadData();
		}

		[Export ("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
		public void willHideViewController(UISplitViewController svc, UIViewController vc, UIBarButtonItem bbi, UIPopoverController poc)
		{
			// If this bar button item doesn't have a title, it won't appear at all.
			bbi.Title = "List";

			// Take this bar button item and put it on the left side of our nav item
			this.NavigationItem.SetLeftBarButtonItem(bbi, true);

			popover = poc;
		}

		[Export ("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
		public void willShowViewController(UISplitViewController svc, UIViewController vc, UIBarButtonItem bbi)
		{
			// Remove the bar button item from our navigation item
			// We'll double check that its the corect button, even though we know it is
			if (bbi == this.NavigationItem.LeftBarButtonItem) {
				this.NavigationItem.SetLeftBarButtonItem(null, true);
			}

			popover = null;
		}
	}
}

