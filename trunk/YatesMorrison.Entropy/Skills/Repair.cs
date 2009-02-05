/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Repair : DerivedAttribute
	{
		public Repair() : base("Repair", "", "", "Science", 0) { }

		public override double Base
		{
			get { return 2 * Actor.GetAspectByName("Intelligence").Total; }
		}
	}
}