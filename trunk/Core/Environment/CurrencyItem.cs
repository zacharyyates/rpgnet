/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */

namespace YatesMorrison.RolePlay
{
	public class CurrencyItem : Item
	{
		public CurrencyItem() { }
		public CurrencyItem( MonetaryValue value )
		{
			m_Value = value;
		}

		public override string GetDebugString()
		{
			return Value.GetDebugString();
		}
	}
}