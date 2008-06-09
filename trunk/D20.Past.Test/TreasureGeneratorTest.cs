/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */

using System;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YatesMorrison.RolePlay;
using YatesMorrison.RolePlay.D20.Past.Treasure;
using YatesMorrison.RolePlay.D20.Past;

namespace D20.Past.Test
{
	/// <summary>
	/// Summary description for GeneratorTest
	/// </summary>
	[TestClass]
	public class TreasureGeneratorTest
	{
		public TreasureGeneratorTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestByEncounterLevel()
		{
			TreasureGenerator generator = new TreasureGenerator();
			int el = 5;
			TestContext.WriteLine("Encounter Level: " + el);
			Collection<Item> items = new Collection<Item>();
			generator.ByEncounterLevel(el, items);
			
			TestContext.WriteLine("Items: " + Environment.NewLine + BuildItemList(items));
		}

		[TestMethod]
		public void TestMundaneItems()
		{
			for( int i = 0; i < 20; i++ )
			{
				TestContext.WriteLine("Mundane test: " + i);
				Collection<Item> items = new Collection<Item>();
				MundaneGenerator gen = new MundaneGenerator(new TreasureDataContext());
				gen.Generate(items);

				TestContext.WriteLine(BuildItemList(items));
			}
		}

		string BuildItemList( Collection<Item> items )
		{
			StringBuilder sb = new StringBuilder();
			foreach( Item item in items )
			{
				sb.AppendLine("\t" + item.GetDebugString());
			}
			return sb.ToString();
		}

		[TestMethod]
		public void TestCoinConversion()
		{
			CoinMonetaryValue value1 = new CoinMonetaryValue(CoinType.Gold, 100); // 100 gold
			CoinMonetaryValue value2 = value1 * 10;
			Assert.AreEqual(1000, value2.Value);

			CoinMonetaryValue value3 = new CoinMonetaryValue(CoinType.Copper, 100); // 1 gold
			CoinMonetaryValue value4 = value3 + new CoinMonetaryValue(CoinType.Silver, 10); // 1 gold
			Assert.AreEqual(2, value4.Value);
		}
	}
}