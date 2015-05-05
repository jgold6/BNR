using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;
using CoreGraphics;
using SQLite;

namespace Homepwner
{
	[Table("BNRAssetTypes")]
	public class BNRAssetType
	{
		[PrimaryKey, AutoIncrement, MaxLength(8)]
		public int ID {get; set;}
		[MaxLength(50), Collation("NoCase")]
		public string assetType {get; set;}

		public BNRAssetType()
		{
		}

		public BNRAssetType(string label)
		{
			assetType = label;
		}
	}
}

