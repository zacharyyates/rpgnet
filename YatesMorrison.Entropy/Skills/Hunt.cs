/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Hunt : DerivedAttribute
	{
		public Hunt() : base("Hunt", "", "", "Survival", 0) { }

		public override double Base
		{
			get { return 10 + 2 * Actor.GetAspectByName("Perception").Total; }
		}
	}
}