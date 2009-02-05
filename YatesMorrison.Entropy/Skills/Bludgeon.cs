/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Bludgeon : DerivedAttribute
	{
		public Bludgeon() : base("Bludgeon", "", "", "Melee", 0) { }

		public override double Base
		{
			get { return 20 + 3 * Actor.GetAspectByName("Strength").Total; }
		}
	}
}