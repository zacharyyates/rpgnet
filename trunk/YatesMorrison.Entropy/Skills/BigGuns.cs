/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class BigGuns : DerivedAttribute
	{
		public BigGuns() : base("Big Guns", "", "", "Marksman", 0) { }

		public override double Base
		{
			get { return 2 * Actor.GetAspectByName("Agility").Total; }
		}
	}
}