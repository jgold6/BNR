using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using System.Collections.Generic;
using CoreGraphics;

namespace Homepwner
{
	public class AssetTypePicker : UITableViewController, IUITableViewDelegate, IUITableViewDataSource
	{
		public BNRItem item {get; set;}
		public UIPopoverController popoverController {get; set;}
		public DetailViewController controller {get; set;}

		public AssetTypePicker() : base(UITableViewStyle.Plain)
		{
			UINavigationItem n = this.NavigationItem;
			n.Title = NSBundle.MainBundle.LocalizedString("Asset Types", "AssetTypes");

			// Create a new bar button item that will send
			// addNewItem to AssetTypePicker
			UIBarButtonItem bbi = new UIBarButtonItem(UIBarButtonSystemItem.Add, addNewItem); // Use for silver challenge

			// Set this bar button item as the right item in the navigationItem // Use for silver challenge
			n.RightBarButtonItem = bbi; // Use for silver challenge
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

//			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) { // Bronze asset type picker popover for iPad
			UIImage image = UIImage.FromBundle("tvBgImage.png");
			TableView.BackgroundView = new UIImageView(image);
//			}
		}

		public void addNewItem(object sender, EventArgs e)
		{ 
			UIAlertView alert = new UIAlertView(
				NSBundle.MainBundle.LocalizedString("Create an Asset Type", "Create Asset Type"),
				NSBundle.MainBundle.LocalizedString("Please enter a new asset type", "Please Enter"),
				null, 
				NSBundle.MainBundle.LocalizedString("Cancel", "Cancel"), 
				new string[]{NSBundle.MainBundle.LocalizedString("Done", "Done")});
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			UITextField alerttextField = alert.GetTextField(0);
			alerttextField.KeyboardType = UIKeyboardType.Default;
			alerttextField.Placeholder = NSBundle.MainBundle.LocalizedString("Enter a new asset type", "Enter New");
			alert.Show(); // Use for silver challenge
			alert.Clicked += (object avSender, UIButtonEventArgs ave) => {
				if (ave.ButtonIndex == 1) {
					Console.WriteLine("Entered: {0}", alert.GetTextField(0).Text);
					BNRItemStore.addAssetType(alert.GetTextField(0).Text);
					TableView.ReloadData();
					NSIndexPath ip = NSIndexPath.FromRowSection(BNRItemStore.allAssetTypes.Count-1, 0);
					this.RowSelected(TableView, ip);
				} else {
					this.NavigationController.PopViewController(true);
				}
			};
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 2;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			int rows;
			if (section == 0)
				rows = BNRItemStore.allAssetTypes.Count;
			else { // Use for gold challenge
				var assetTypeItems = getAssetTypeItems();
				rows = assetTypeItems.Count;
			}
			return rows;
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 30;
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var headerView = new UILabel(new CGRect(0, 0, tableView.Frame.Width, tableView.EstimatedSectionHeaderHeight));
			headerView.TextAlignment = UITextAlignment.Center;
			headerView.Font = UIFont.BoldSystemFontOfSize (20);

			if (section == 0)
				headerView.Text = String.Format(NSBundle.MainBundle.LocalizedString("Asset type for ", "Asset Type for") + item.itemName);
			else
				headerView.Text = String.Format(NSBundle.MainBundle.LocalizedString("All ", "All") + 
					NSBundle.MainBundle.LocalizedString(((item.assetType == "" || item.assetType == null) ? "Unassigned" : item.assetType), "Asset Type") + 
					NSBundle.MainBundle.LocalizedString(" items", "Items"));
			return headerView;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = TableView.DequeueReusableCell("UITableViewCell");
			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Default, "UITableViewCell");
			}

			if (indexPath.Section == 0) {
				var at = BNRItemStore.allAssetTypes[indexPath.Row];
				cell.TextLabel.Text = NSBundle.MainBundle.LocalizedString(at.assetType, "AssetType");

				if (at.assetType == item.assetType)
					cell.Accessory = UITableViewCellAccessory.Checkmark;
				else
					cell.Accessory = UITableViewCellAccessory.None;
			} 
			if (indexPath.Section == 1) { 
				var assetTypeItems = getAssetTypeItems();
				var at = assetTypeItems[indexPath.Row];
				cell.TextLabel.Text = at.itemName;
				cell.Accessory = UITableViewCellAccessory.None;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			}
			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0) {
				foreach (UITableViewCell c in tableView.VisibleCells)
					c.Accessory = UITableViewCellAccessory.None;

				UITableViewCell cell = tableView.CellAt(indexPath);

				if (cell != null) 
					cell.Accessory = UITableViewCellAccessory.Checkmark;

				var at = BNRItemStore.allAssetTypes[indexPath.Row];
				item.assetType = at.assetType;
				BNRItemStore.updateDBItem(item);
//				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) { // Bronze, asset type picker popover for iPad
//					controller.updateAssetType(); // Bronze
//					popoverController.Dismiss(true); // Bronze
//					popoverController = null; // Bronze
//				} else { // Bronze
					this.NavigationController.PopViewController(true);
//				} // Bronze
			}
		}

		public List<BNRItem> getAssetTypeItems()
		{
			List<BNRItem> assetTypeItems = new List<BNRItem>();
			var items = BNRItemStore.allItems;

			foreach (BNRItem i in items) {
				if (i.assetType == item.assetType) {
					assetTypeItems.Add(i);
				} 
			} 
			return assetTypeItems;
		}
	}
}

