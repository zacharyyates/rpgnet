/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class HandleAnimal : DerivedAttribute
	{
		public HandleAnimal() : base("Handle Animal", "", "", "Survival", 0) { }

		public override double Base
		{
			get
			{
				return Actor.GetAspectByName("Perception").Total +
					Actor.GetAspectByName("Intelligence").Total +
					Actor.GetAspectByName("Agility").Total;
			}
		}
	}
}