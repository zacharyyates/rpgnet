/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class CarryWeight : DerivedAttribute
	{
		public CarryWeight() : base("Carry Weight", "CW", "", "Strength", 0) { }

		public override double Base
		{
			get { return 25 * Attribute.Total + 25; }
		}
	}
}