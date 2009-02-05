/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class DamageResistance : DerivedAttribute
	{
		public DamageResistance() : base("Damage Resistance", "DR", "", "Endurance", 0) { }
	}
}