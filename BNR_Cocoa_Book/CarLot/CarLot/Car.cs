using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace CarLot
{
	[Register("Car")]
    public class Car : NSObject
    {
		#region - Properties
		[Export("makeModel")]
		public string MakeModel {get; set;}

		[Export("datePurchased")]
		public NSDate DatePurchased {get; set;}

		[Export("condition")]
		public int Condition {get; set;}

		[Export("onSpecial")]
		public bool OnSpecial {get; set;}

		[Export("price")]
		public float Price {get; set;}

		[Export("photo")]
		public NSImage Photo {get; set;}
		#endregion

		#region - Constructors
		public Car()
		{
			MakeModel = "New Car";
			Price = 0.0f;
			DatePurchased = NSDate.Now;
			OnSpecial = false;
			Condition = 3;
		}

		[Export("initWithCoder:")]
		public Car(NSCoder decoder)
		{
			NSString str = (NSString)decoder.DecodeObject("makeModel");
			if (str != null)
				this.MakeModel = str.ToString();

			DatePurchased = (NSDate)decoder.DecodeObject("datePurchased");

			this.Condition = decoder.DecodeInt("condition");

			this.OnSpecial = decoder.DecodeBool("onSpecial");

			this.Price = decoder.DecodeFloat("price");

			this.Photo = (NSImage)decoder.DecodeObject("photo");
		}
		#endregion

		#region - Overrides
		public override void EncodeTo(NSCoder coder)
		{
			if (this.MakeModel != null)
				coder.Encode(new NSString(this.MakeModel), "makeModel");

			if (this.DatePurchased != null)
				coder.Encode(this.DatePurchased, "datePurchased");

			coder.Encode(this.Condition, "condition");

			coder.Encode(this.OnSpecial, "onSpecial");

			coder.Encode(this.Price, "price");

			if (this.Photo != null)
				coder.Encode(this.Photo, "photo");
		}

		public override void SetNilValueForKey(NSString key)
		{
			switch (key.ToString()) {
				case "price":
					this.Price = 0.0f;
					break;
				default:
					base.SetNilValueForKey(key);
					break;
			}
		}
		#endregion
    }
}

