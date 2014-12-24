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

		public override void SetNilValueForKey(NSString key)
		{
			if (key.ToString() == "expectedRaise")
				ExpectedRaise = 0.0f;
			else
				base.SetNilValueForKey(key);
		}
    }
}

