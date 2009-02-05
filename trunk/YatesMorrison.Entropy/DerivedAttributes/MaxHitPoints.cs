/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class MaxHitPoints : DerivedAttribute
	{
		public MaxHitPoints() : base("Max Hit Points", "MHP", "", "Endurance", 0) { }

		public override double Base
		{
			get
			{
				return 2 * Actor.GetAspectByName("Endurance").Total +
					Actor.GetAspectByName("Strength").Total +
					15;
			}
		}
	}
}