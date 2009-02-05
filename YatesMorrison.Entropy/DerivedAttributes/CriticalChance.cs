/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1/6/2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class CriticalChance : DerivedAttribute
	{
		public CriticalChance() : base("Critical Chance", "CC", "", "Luck", 0) { }
	}
}