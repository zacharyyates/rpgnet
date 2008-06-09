/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */


namespace YatesMorrison.RolePlay
{
	public class StackableItem : Item
	{
		public int Quantity
		{
			get { return m_Quantity; }
			set { m_Quantity = value; }
		}
		int m_Quantity;

		public override double Weight
		{
			get { return m_Weight * m_Quantity; }
			set { m_Weight = value; }
		}

		public override string GetDebugString()
		{
			return Quantity + " " + base.GetDebugString();
		}
	}
}