/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;

	[Serializable]
	public class Inventory
	{
		public List<InventorySlot> Slots
		{
			get { return m_Slots; }
		}
		List<InventorySlot> m_Slots = new List<InventorySlot>();
	}
}