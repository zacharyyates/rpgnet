/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.Entropy
{
	using System;

	[Serializable]
	public class Armor : YatesMorrison.RolePlay.Armor
	{
		public double Soak { get; set; }
		public double Threshold { get; set; }
	}
}