using NUnit.Framework;
using System;

namespace Random.Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
			Assert.AreEqual("Success!", TestMethods.GetString());
        }
    }
}

