/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.RolePlay.Extensions
{
	using System;

	[Serializable]
	public class AttributeInstance
	{
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public double InitialScore { get; set; }
	}
}