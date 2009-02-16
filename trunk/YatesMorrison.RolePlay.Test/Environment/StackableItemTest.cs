/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.RolePlay.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Tests the StackableItem class
	/// </summary>
	[TestClass]
	public class StackableItemTest
	{
		/// <summary>
		/// Gets or sets the test context which provides information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestSplit()
		{
			var item1 = new StackableItem()
			{
				Quantity = 5,
				Name = "Test Stackable"
			};

			var split = item1.Split(3);

			Assert.AreEqual(3, split.First.Quantity, "Expected 3 items in the first stack");
			Assert.AreEqual(2, split.Second.Quantity, "Expected 2 items in the second stack");
		}
	}
}
