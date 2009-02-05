﻿/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Steal : DerivedAttribute
	{
		public Steal() : base("Steal", "", "", "Subterfuge", 0) { }

		public override double Base
		{
			get { return 3 * Actor.GetAspectByName("Agility").Total; }
		}
	}
}