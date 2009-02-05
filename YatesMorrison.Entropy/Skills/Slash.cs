/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Slash : DerivedAttribute
	{
		public Slash() : base("Slash", "", "", "Melee", 0) { }

		public override double Base
		{
			get { return 10 + 3 * Actor.GetAspectByName("Strength").Total; }
		}
	}
}