/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.RolePlay.Tests
{
	using System.Diagnostics;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Tests the StackableItem class
	/// </summary>
	[TestClass]
	public class WeaponTest
	{
		/// <summary>
		/// Gets or sets the test context which provides information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestUse()
		{
			var knife = new Knife();
			Damage dmg = knife.Use() as Damage;

			Assert.IsNotNull(dmg);
			Assert.IsTrue(dmg.Max >= 1);
			Assert.IsTrue(dmg.Max <= 10);
			Debug.WriteLine("Damage: " + dmg.Max);
		}
	}

	class Knife : Weapon
	{
		protected override IDamage GetDamage()
		{
			return new Damage() { Max = Dice.Roll(DieType.D10) };
		}
	}

	class Damage : IDamage
	{
		public double Max { get; set; }

		public void Execute(Actor actor)
		{
			throw new System.NotImplementedException();
		}
	}
}
