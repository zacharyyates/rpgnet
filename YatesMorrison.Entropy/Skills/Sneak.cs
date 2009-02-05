/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Sneak : DerivedAttribute
	{
		public Sneak() : base("Sneak", "", "", "Subterfuge", 0) { }

		public override double Base
		{
			get { return 3 * Actor.GetAspectByName("Agility").Total; }
		}
	}
}