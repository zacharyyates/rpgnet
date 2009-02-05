/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Forage : DerivedAttribute
	{
		public Forage() : base("Forage", "", "", "Survival", 0) { }

		public override double Base
		{
			get { return 4 * Actor.GetAspectByName("Intelligence").Total; }
		}
	}
}