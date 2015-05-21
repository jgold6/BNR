using System;
using CoreGraphics;
using Foundation;
using UIKit;
using ObjCRuntime;

namespace Homepwner
{
	public partial class ItemsViewController : UITableViewController, IUITableViewDataSource, IUITableViewDelegate, IUIPopoverControllerDelegate
	{
		public HeaderCell headerCell {get; set;}
		UIPopoverController imagePopover {get; set;}

		public ItemsViewController() : base(UITableViewStyle.Plain)
		{
			UINavigationItem n = this.NavigationItem;
			n.Title = NSBundle.MainBundle.LocalizedString("Homepwner", "Application Name");

			// Create a new bar button item that will send
			// addNewItem to ItemsViewController
			UIBarButtonItem bbi = new UIBarButtonItem(UIBarButtonSystemItem.Add, addNewItem);

			// Set this bar button item as the right item in the navigationItem
			n.RightBarButtonItem = bbi;
			n.LeftBarButtonItem = this.EditButtonItem;
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			UIImage image = UIImage.FromBundle("tvBgImage.png");
			TableView.BackgroundView = new UIImageView(image);
			BNRItemStore.loadItemsFromDatabase();
			NSNotificationCenter nc = NSNotificationCenter.DefaultCenter;
			nc.AddObserver(this, new Selector("clearImageCache:"), UIApplication.DidReceiveMemoryWarningNotification, null);

			// HomepwnerItemCell
			UINib nib = UINib.FromName("HomepwnerItemCell", null);
			// Register this NIB which contains the cell
			TableView.RegisterNibForCellReuse(nib, "HomepwnerItemCell");

			//TableView.SeparatorInset = new UIEdgeInsets(0, 0, 0, 0);
		}

		[Export("clearImageCache:")]
		public void ClearImageCache(NSNotification note)
		{
			Console.WriteLine("Low Memory warning: {0}", note.ToString());
			BNRImageStore.clearCache();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.TableView.ReloadData();
		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return BNRItemStore.allItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			// Check for a reusable cell first, use that if it exists - before using nib
//			UITableViewCell cell = tableView.DequeueReusableCell("UITableViewCell");
//
//			if (cell == null)
//				// Create an instance of UITableViewCell, with default appearance
//				cell = new UITableViewCell(UITableViewCellStyle.Subtitle,"UITableViewCell");

			// Set the text on the cell with the description of the item
			// that is the nth index of items, where n = row this cell
			// will appear in on the tableView
			BNRItem p = BNRItemStore.allItems[indexPath.Row];

//			cell.TextLabel.Text = String.Format("Item: {0}, ${1}", p.itemName, p.valueInDollars);
//			cell.DetailTextLabel.Text = String.Format("SN: {0}, Added: {1}", p.serialNumber, p.dateCreated);
//			cell.BackgroundColor = UIColor.FromRGBA(1.0f, 1.0f, 1.0f, 0.5f);

			HomepwnerItemCell cell = tableView.DequeueReusableCell("HomepwnerItemCell") as HomepwnerItemCell;

			if (cell.nudgeValueCallback == null) {
				cell.nudgeValueCallback = nudgeItemValue;
				cell.showImageCallback = showImageAtIndexPath;
			}

			// Configure the cell
			cell.nameLabel.Text = p.itemName;
			cell.serialNumberLabel.Text = p.serialNumber;
			string currencySymbol = NSLocale.CurrentLocale.CurrencySymbol;
			cell.valueLabel.Text = String.Format("{0}{1}", currencySymbol ,p.valueInDollars);
			if (p.valueInDollars < 0) 
			{
				cell.valueLabel.TextColor = UIColor.Red;
			}
			else 
			{
				cell.valueLabel.TextColor = UIColor.Black;
			}
			cell.stepper.MaximumValue = p.valueInDollars + 500;
			cell.stepper.MinimumValue = p.valueInDollars - 500;
			cell.stepper.Value = p.valueInDollars;

			string thumbKey = p.imageKey + ".thumbnail"; // Changed from archiving method of saving for SQL method

			// If there is no image, we don;t need to do anything // For archiving method of saving
			UIImage img = BNRImageStore.imageForKey(thumbKey); // Changed from archiving method of saving for SQL method
//			if (img == null) // For archiving method of saving
//				return; // For archiving method of saving

			cell.thumbnailView.Image = img;

//			cell.thumbnailView.Image = p.Thumbnail(); // Archiving method of saving

			return cell;
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			if (headerCell == null)
			{
				headerCell = new HeaderCell();
				var views = NSBundle.MainBundle.LoadNib("HeaderCell", headerCell, null);
				headerCell = Runtime.GetNSObject(views.ValueAt(0)) as HeaderCell;
				headerCell.BackgroundColor = UIColor.Clear;
			}
			return headerCell.Bounds.Size.Height;
		}

		public override UIView GetViewForHeader (UITableView tableView, nint section)
		{
			return headerCell;
		}

		public override void WillBeginEditing(UITableView tableView, NSIndexPath indexPath)
		{
			base.WillBeginEditing(tableView, indexPath);
			UITableViewCell cell = tableView.CellAt(indexPath);
			cell.BackgroundColor = UIColor.Yellow;
		}

		public override void DidEndEditing(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath != null) {
				base.DidEndEditing(tableView, indexPath);
				UITableViewCell cell = tableView.CellAt(indexPath);
				if (cell != null)
					cell.BackgroundColor = UIColor.White;
			}
		}

		public override void MoveRow(UITableView tableView, NSIndexPath fromIndexPath, NSIndexPath toIndexPath)
		{
			BNRItemStore.moveItem(fromIndexPath.Row, toIndexPath.Row);
			foreach (BNRItem i in BNRItemStore.allItems) 
				Console.WriteLine("ordering value for item {0} = {1}", BNRItemStore.allItems.IndexOf(i), i.orderingValue);
		}

		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			//base.CommitEditingStyle(tableView, editingStyle, indexPath);
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				UITableViewCell cell = tableView.CellAt(indexPath);
				if (cell != null)
					cell.BackgroundColor = UIColor.White;
				BNRItem itemToRemove = BNRItemStore.allItems[indexPath.Row];
				BNRItemStore.RemoveItem(itemToRemove);
				NSIndexPath[] indexPaths = new NSIndexPath[] {indexPath};
				TableView.DeleteRows(indexPaths, UITableViewRowAnimation.Automatic);
				Console.WriteLine("allItems: {0}, tableViewRows: {1}", BNRItemStore.allItems.Count, tableView.NumberOfRowsInSection(0));
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			// Make a detail view controller
			DetailViewController detailViewController = new DetailViewController(false);
			detailViewController.EdgesForExtendedLayout = UIRectEdge.None;

			// Get the selected BNRItem
			var items = BNRItemStore.allItems;
			BNRItem selectedItem = items[indexPath.Row];

			// Give the detailViewController a pointer to the item object in row
			detailViewController.Item = selectedItem;

			// Push it onto the top of the navigation controller's stack
			this.NavigationController.PushViewController(detailViewController, true);

		}

		void addNewItem(object sender, EventArgs e)
		{
			Console.WriteLine("BtnAdd pressed");

			BNRItem newItem = BNRItemStore.CreateItem();

//			int lastRow = BNRItemStore.allItems.IndexOf(newItem);
//
//			NSIndexPath ip = NSIndexPath.FromRowSection(lastRow, 0);
//
//			NSIndexPath[] indexPaths = new NSIndexPath[] {ip};
//			TableView.InsertRows(indexPaths, UITableViewRowAnimation.Automatic);

			DetailViewController detailViewController = new DetailViewController(true);
			detailViewController.EdgesForExtendedLayout = UIRectEdge.None;

			detailViewController.Item = newItem;

			UINavigationController navController = new UINavigationController(detailViewController);
			navController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
			navController.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;

			this.PresentViewController(navController, true, null);

			Console.WriteLine("allItems: {0}, tableViewRows: {1}", BNRItemStore.allItems.Count, TableView.NumberOfRowsInSection(0));
		}

		public void showImageAtIndexPath(NSObject sender, HomepwnerItemCell cell)
		{
			NSIndexPath indexPath = TableView.IndexPathForCell(cell);
			Console.WriteLine("Going to show the image for {0}", indexPath);

			// Get the item for the index path
			BNRItem i = BNRItemStore.allItems[indexPath.Row];

			string imageKey = i.imageKey;
			// If there is no image, we don't need to do anything
			if (imageKey == null || imageKey == "")
				return;

			UIImage img = BNRImageStore.imageForKey(imageKey);

			// Create a new ImageViewController and set its image
			ImageViewController ivc = new ImageViewController();
			ivc.Image = img;
			ivc.PopoverSize = new CGSize(600, 600);

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				// Make a rectangle that the frame of the button relative to our table view
				UIButton btn = sender as UIButton;
				CGRect rect = View.ConvertRectFromView(btn.Bounds, btn);

				// Present a 600 x 600 popover from the rect
				imagePopover = new UIPopoverController(ivc);
				imagePopover.PopoverContentSize = ivc.PopoverSize;

				imagePopover.DidDismiss += (object pSender, EventArgs e) => {
					imagePopover.Dismiss(true);
					imagePopover = null;
				};

				imagePopover.PresentFromRect(rect, View, UIPopoverArrowDirection.Any, true);

			}
			else {
				this.NavigationController.PushViewController(ivc, true);
			}
		}

		public void nudgeItemValue(HomepwnerItemCell cell, double stepperValue)
		{
			NSIndexPath indexPath = TableView.IndexPathForCell(cell);
			BNRItem i = BNRItemStore.allItems[indexPath.Row];
			i.valueInDollars = (int)stepperValue;
			BNRItemStore.updateDBItem(i);
			TableView.ReloadData();
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return true;
			} else {
				return false;
			}
		}
	}
}
