using System;
using UIKit;
using Foundation;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ObjCRuntime;
using CoreGraphics;

namespace Nerdfeed
{
	public enum ListViewControllerRSSType {BNRFeed, Apple};

	public sealed class ListViewController : UITableViewController
	{

		public WebViewController webViewController {get; set;}
		public ChannelViewController channelViewController {get; set;}
		ListViewControllerRSSType rssType;
		UISegmentedControl rssTypeControl;
		int numberOfSongsToGet;
		int currentItemCount;

		public ListViewController() : this(UITableViewStyle.Plain)
		{
		}

		public ListViewController(UITableViewStyle style) : base(style)
		{

			numberOfSongsToGet = 20;
			UIBarButtonItem bbi = new UIBarButtonItem();
			bbi.Title = "Info";
			bbi.Style = UIBarButtonItemStyle.Bordered;
			this.NavigationItem.SetRightBarButtonItem(bbi,true);
			bbi.Clicked += (object sender, EventArgs e) => {
				// Create the channel view controller
				channelViewController = new ChannelViewController(UITableViewStyle.Grouped);

				if (this.SplitViewController != null) {
					this.transferBarButtonItem(channelViewController);
					UINavigationController nvc = new UINavigationController(channelViewController);

					// Create an array with our nav controller and this new VC's nav controller
					UINavigationController[] vcs = new UINavigationController[]{this.NavigationController, nvc};

					// Grab a pointer to the split view controller
					// and reset its view controllers array
					this.SplitViewController.ViewControllers = vcs;

					// Make detail view controller the delegate of the split view controller
					// - ignore the warning for now
					this.SplitViewController.WeakDelegate = channelViewController;
					if (webViewController.popover != null)
						webViewController.popover.Dismiss(true);

					// If a row has been selected, deselect it so that a row
					// is not selected when viewing the info
					NSIndexPath selectedRow = this.TableView.IndexPathForSelectedRow;
					if (selectedRow != null)
						this.TableView.DeselectRow(selectedRow, true);

				} else {
					this.NavigationController.PushViewController(channelViewController, true);
				}

				// Give the VC the channel object through the interface method
				channelViewController.listViewControllerHandleObject(this, BNRFeedStore.channel);

			};

			rssType = ListViewControllerRSSType.BNRFeed;
			rssTypeControl = new UISegmentedControl(new string[]{"Onobytes", "Apple"});
			rssTypeControl.SelectedSegment = 0;

			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0) || UIDevice.CurrentDevice.CheckSystemVersion(7,1))
				rssTypeControl.TintAdjustmentMode = UIViewTintAdjustmentMode.Normal;
			rssTypeControl.ValueChanged += (object sender, EventArgs e) => {
				rssType = (ListViewControllerRSSType)(int)rssTypeControl.SelectedSegment;
				if (rssType == ListViewControllerRSSType.Apple) {

					BNRFeedStore.items.Clear();

					// Alert to select number of songs
					UIAlertView aiView = new UIAlertView("Get Top Songs", "Enter how many songs to get", null, "OK", null);
					aiView.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
					aiView.GetTextField(0).Text = numberOfSongsToGet.ToString();
					aiView.GetTextField(0).KeyboardType = UIKeyboardType.NumberPad;
					aiView.WeakDelegate = this;
					aiView.Show();

					// Comment out if above is commented in
//					this.TableView.ReloadData();
//					fetchEntries();
				}
				else {
					BNRFeedStore.items.Clear();
					this.TableView.ReloadData();
					fetchEntries();
				}
			};
			this.NavigationItem.TitleView = rssTypeControl;
			this.TableView.BackgroundColor = UIColor.Black;
			fetchEntries();
		}

		void fetchEntries()
		{
			UIView currentTitleView = this.NavigationItem.TitleView;

			// Create an activity indicator and start it spinning
			UIActivityIndicatorView aiView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
			this.NavigationItem.TitleView = aiView;
			aiView.StartAnimating();

			BNRFeedStore.Block completionBlock = delegate(string error) {
				this.NavigationItem.TitleView = currentTitleView;
				if (error == "success") {
					if (rssType == ListViewControllerRSSType.BNRFeed) {
						int newItemCount = BNRFeedStore.items.Count;
						int itemDelta = newItemCount - currentItemCount;
						if (itemDelta > 0) {
							List<NSIndexPath> rows = new List<NSIndexPath>();
							for (int i = 0; i < itemDelta; i++) {
								NSIndexPath ip = NSIndexPath.FromRowSection(i, 0);
								rows.Add(ip);
							}
							this.TableView.InsertRows(rows.ToArray(), UITableViewRowAnimation.Top);
							this.TableView.ReloadData();
						}
					}
					else {
						this.TableView.ReloadData();
					}
				}
				else {
					UIAlertView av = new UIAlertView("Error", error, null, "OK", null);
					av.Show();
				}
			};
			if (rssType == ListViewControllerRSSType.BNRFeed) {
				BNRFeedStore.FetchRSSFeed(completionBlock);
				currentItemCount = BNRFeedStore.items.Count;
				this.TableView.ReloadData();
			}
			else if (rssType == ListViewControllerRSSType.Apple) {
				BNRFeedStore.FetchRSSFeedTopSongs(numberOfSongsToGet, completionBlock);
			}
		}

		[Export ("alertView:clickedButtonAtIndex:")]
		public void AVClickedButton(UIAlertView av, int btnIndex)
		{
			string text = av.GetTextField(0).Text;
			try {
				numberOfSongsToGet = Convert.ToInt32(text);
				if (numberOfSongsToGet < 2 || numberOfSongsToGet > 400) {
					UIAlertView aView = new UIAlertView("Invalid Entry", "Please enter integer between 2 and 400\nUsing default of 10", null, "OK", null);
					aView.Show();
					numberOfSongsToGet = 10;
				}
			}
			catch {
				UIAlertView aView = new UIAlertView("Invalid Entry", "Please enter integer between 2 and 400\nUsing default of 10", null, "OK", null);
				aView.Show();
				numberOfSongsToGet = 10;
			}
			this.TableView.ReloadData();
			fetchEntries();
		}

		public override void ViewWillAppear(bool animated)
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				webViewController.webView.Init();
				webViewController.webView.ScalesPageToFit = true;
			}
			this.NavigationController.NavigationBar.TintColor = UIColor.LightGray;
			this.NavigationController.NavigationBar.Translucent = false;
			this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
//			UIView statusBarBackground = new UIView(new RectangleF(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
//			statusBarBackground.BackgroundColor = UIColor.DarkGray;
//			statusBarBackground.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin);
//			this.NavigationController.View.Add(statusBarBackground);
//			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0) || UIDevice.CurrentDevice.CheckSystemVersion(7,1))
//				this.NavigationController.View.TintColor = UIColor.Green;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return BNRFeedStore.items.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath )
		{
			// get cell to reuse or create new one.
			UITableViewCell cell;
			if (rssType == ListViewControllerRSSType.BNRFeed) {
				cell = tableView.DequeueReusableCell("UITableViewCellBNR");
				if (cell == null) {
					cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCellBNR");
				}
			}
			else {
				cell = tableView.DequeueReusableCell("UITableViewCellApple");
				if (cell == null) {
					cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCellApple");
				}
			}

			// Get item and initialize cell with item info
			RSSItem item = BNRFeedStore.items[indexPath.Row];
			cell.TextLabel.Text = item.title;
			cell.TextLabel.TextColor = UIColor.Yellow;
			cell.DetailTextLabel.Text = item.subForum;
			cell.DetailTextLabel.TextColor = UIColor.Yellow;
			cell.UserInteractionEnabled = true;
			cell.BackgroundColor = UIColor.Clear;
			cell.Accessory = UITableViewCellAccessory.None;
			cell.SelectedBackgroundView = new UIView(){
				Frame = cell.Frame,
				BackgroundColor = UIColor.FromRGB(0.3f, 0.3f, 0.3f)
			};

			// For BNRFeed list. set up Favbutton, check if favorite, decorate button accordingly, add to cell view
			if (rssType == ListViewControllerRSSType.BNRFeed) {
				UIButton favButton = new UIButton(UIButtonType.RoundedRect);

				favButton.Frame = new CGRect(cell.Frame.Size.Width-17, 0, 17, 44);
				favButton.AddTarget(this, new Selector("favButtonPressed:"), UIControlEvent.TouchUpInside);
				favButton.SetTitle("F", UIControlState.Normal);
				favButton.SetTitleColor(UIColor.White, UIControlState.Normal);
				favButton.BackgroundColor = UIColor.FromRGB(0.3f, 0.3f, 0.3f);
				favButton.Tag = indexPath.Row;
				favButton.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;
				cell.BringSubviewToFront(favButton);

				if (item.isFavorite) {
					favButton.SetTitleColor(UIColor.Green, UIControlState.Normal);
					favButton.BackgroundColor = UIColor.FromRGB(0.4f, 0.4f, 0.4f);
				}
				cell.AddSubview(favButton);
			}

			// Set checkmark for read items. 
			if (item.isRead)
				cell.Accessory = UITableViewCellAccessory.Checkmark;

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (this.SplitViewController == null) {
				// Push the web view controller onto the navigation stack
				// this implicitly creates the web view controller's view the first time through
				this.NavigationController.PushViewController(webViewController, true);
			} else {
				this.transferBarButtonItem(webViewController);
				// We have to create a new Navigation controller, as the old one
				// was only retained by the split view controller and is now gone
				UINavigationController nav = new UINavigationController(webViewController);

				UIViewController[] vcs = new UIViewController[]{this.NavigationController, nav};

				this.SplitViewController.ViewControllers = vcs;

				// Make the detail view controller the delegate of the split view controller
				// - ignore this warning
				this.SplitViewController.WeakDelegate = webViewController;
				if (webViewController.popover != null)
					webViewController.popover.Dismiss(true);
			}

			// grab the selected item
			RSSItem entry = BNRFeedStore.items[indexPath.Row];

			if (rssType == ListViewControllerRSSType.BNRFeed) {
				entry.isRead = true;
				BNRFeedStore.updateItem(entry);
				tableView.CellAt(indexPath).Accessory = UITableViewCellAccessory.Checkmark;
			}

			webViewController.listViewControllerHandleObject(this, entry);
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				return true;
			return InterfaceOrientation == UIInterfaceOrientation.Portrait;
		}

		public void transferBarButtonItem(UIViewController vc)
		{
			// Get the navigation controller in the detail spot of the split view controller
			UINavigationController nvc = this.SplitViewController.ViewControllers[1] as UINavigationController;

			// Get the root view controller out of that nav controller
			UIViewController currentVC = nvc.ViewControllers[0] as UIViewController;

			// If it's the same view controller, let's not do anything
			if (vc == currentVC)
				return;

			// Get that view controller's navigation item
			UINavigationItem currentVCItem = currentVC.NavigationItem;

			// Tell the new view controller to use thleft bar button item of current nav item
			vc.NavigationItem.SetLeftBarButtonItem(currentVCItem.LeftBarButtonItem, true);

			// Remove the bar button item from the current view controller's nav item
			currentVCItem.SetLeftBarButtonItem(null, true);
		}

		[Export ("favButtonPressed:")]
		public void favButtonPressed(UIButton favBtn)
		{
			Console.WriteLine("Favorite Button Pressed: {0}", favBtn);
			RSSItem item = BNRFeedStore.items[(int)favBtn.Tag];
			BNRFeedStore.markItemAsFavorite(item);
			this.TableView.ReloadData();
		}
	}

	public interface IListViewControllerDelegate
	{
		// Classes that conform to this interface must implement this method
		void listViewControllerHandleObject(ListViewController lvc, object obj);
	}
}

