/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class BiologicalResistance : DerivedAttribute
	{
		public BiologicalResistance() : base("Biological Resistance", "BR", "", "Endurance", 0) { }

		public override double Base
		{
			get { return 5 * Parent.Total; }
		}
	}
}