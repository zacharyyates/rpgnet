/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class MeleeDamage : DerivedAttribute
	{
		public MeleeDamage() : base("Melee Damage", "MD", "", "Strength", 0) { }

		public override double Base
		{
			get { return (Parent.Total - 5 > 1 ? Parent.Total - 5 : 1); }
		}
	}
}