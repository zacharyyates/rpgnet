﻿/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */

namespace YatesMorrison.RolePlay
{
	public class StackableItem : Item
	{
		public int Quantity { get; set; }

		public override double Weight
		{
			get { return m_Weight * Quantity; }
			set { m_Weight = value; }
		}

		public override string ToString()
		{
			return Quantity + " " + base.ToString();
		}
	}
}