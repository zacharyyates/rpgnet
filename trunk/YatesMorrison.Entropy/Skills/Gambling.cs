/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Gambling : DerivedAttribute
	{
		public Gambling() : base("Gambling", "", "", "Subterfuge", 0) { }

		public override double Base
		{
			get { return 5 * Actor.GetAspectByName("Luck").Total; }
		}
	}
}