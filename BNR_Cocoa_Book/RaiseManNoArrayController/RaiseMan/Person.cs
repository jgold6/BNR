using System;
using MonoMac.Foundation;

namespace RaiseMan
{
	[Register("Person")]
    public class Person : NSObject
    {
		[Export("name")]
		public string Name {get; set;}
		 
		[Export("expectedRaise")]
		public float ExpectedRaise {get; set;}
        
		public Person()
        {
			ExpectedRaise = 0.05f;
			Name = "New Person";
        }

		[Export("initWithCoder:")]
		public Person(NSCoder decoder)
		{
			NSString str = (NSString)decoder.DecodeObject("name");
			if (str != null)
				this.Name = str.ToString();
			this.ExpectedRaise = decoder.DecodeFloat("expectedRaise");
		}

		public override void EncodeTo(NSCoder coder)
		{
			if (this.Name != null)
				coder.Encode(new NSString(this.Name), "name");
			coder.Encode(this.ExpectedRaise, "expectedRaise");
		}


		public override void SetNilValueForKey(NSString key)
		{
			if (key.ToString() == "expectedRaise")
				ExpectedRaise = 0.0f;
			else
				base.SetNilValueForKey(key);
		}
    }
}

