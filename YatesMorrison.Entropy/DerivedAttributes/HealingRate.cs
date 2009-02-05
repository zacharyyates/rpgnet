/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class HealingRate : DerivedAttribute
	{
		public HealingRate() : base("Healing Rate", "HR", "", "Endurance", 0) { }

		public override double Base
		{
			get { return Math.Round(Attribute.Total * 0.5); }
		}
	}
}