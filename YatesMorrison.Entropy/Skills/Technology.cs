﻿/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/10/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Technology : DerivedAttribute
	{
		public Technology() : base("Technology", "", "", "Science", 0) { }

		public override double Base
		{
			get { return Actor.GetAspectByName("Intelligence").Total; }
		}
	}
}