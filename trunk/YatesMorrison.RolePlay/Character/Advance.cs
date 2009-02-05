/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.31.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Advance
	{
		public string AttributeName { get; set; }
		public Attribute Attribute { get; set; }
		public double Value { get; set; }
		public bool IsActive { get; set; }
	}
}