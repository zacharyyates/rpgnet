/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

namespace YatesMorrison.RolePlay
{
	public class ItemSpecialAbility
	{
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
		string m_Name = string.Empty;

		public int BasePriceModifier
		{
			get { return m_BasePriceModifier; }
			set { m_BasePriceModifier = value; }
		}
		int m_BasePriceModifier;

		public MonetaryValue AdditionalPriceModifier
		{
			get { return m_AdditionalPriceModifier; }
			set { m_AdditionalPriceModifier = value; }
		}
		MonetaryValue m_AdditionalPriceModifier;
	}
}