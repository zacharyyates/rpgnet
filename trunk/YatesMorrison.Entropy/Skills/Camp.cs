/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Camp : DerivedAttribute
	{
		public Camp() : base("Camp", "", "", "Survival", 0) { }

		public override double Base
		{
			get { return 10 + 5 * Actor.GetAspectByName("Intelligence").Total; }
		}
	}
}