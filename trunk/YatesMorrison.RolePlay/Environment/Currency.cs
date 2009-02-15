/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software Company
 * 1.22.2008
 */
namespace YatesMorrison.RolePlay
{
	public class Currency : Item
	{
		public Currency() { }
		public Currency( MonetaryValue value )
		{
			m_Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}