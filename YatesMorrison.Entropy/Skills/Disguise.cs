/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Disguise : DerivedAttribute
	{
		public Disguise() : base("Disguise", "", "", "Subterfuge", 0) { }

		public override double Base
		{
			get { return 10 + Actor.GetAspectByName("Charisma").Total + Actor.GetAspectByName("Intelligence").Total; }
		}
	}
}