/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class RadiationResistance : DerivedAttribute
	{
		public RadiationResistance() : base("Radiation Resistance", "RR", "", "Endurance", 0) { }

		public override double Base
		{
			get { return 2 * Attribute.Total; }
		}
	}
}