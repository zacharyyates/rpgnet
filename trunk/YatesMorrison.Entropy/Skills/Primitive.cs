/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Primitive : DerivedAttribute
	{
		public Primitive() : base("Primitive", "", "", "Marksman", 0) { }

		public override double Base
		{
			get { return 10 + 5 * Actor.GetAspectByName("Agility").Total; }
		}
	}
}