/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Throw : DerivedAttribute
	{
		public Throw() : base("Throw", "", "", "Melee", 0) { }

		public override double Base
		{
			get { return 3 * Actor.GetAspectByName("Strength").Total; }
		}
	}
}