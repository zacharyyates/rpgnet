/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/23/2008
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class MonetaryValue
	{
		public MonetaryValue() { }
		public MonetaryValue( double value )
		{
			m_Value = value;
		}

		public virtual double Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		protected double m_Value;

		public override string ToString()
		{
			return Value.ToString();
		}

		#region Operators

		public static MonetaryValue operator +( MonetaryValue value1, MonetaryValue value2 )
		{
			return new MonetaryValue(value1.m_Value + value2.m_Value);
		}

		public static MonetaryValue operator -( MonetaryValue value1, MonetaryValue value2 )
		{
			return new MonetaryValue(value1.m_Value - value2.m_Value);
		}

		public static MonetaryValue operator +( MonetaryValue value1, double value2 )
		{
			return new MonetaryValue(value1.m_Value + value2);
		}

		public static MonetaryValue operator -( MonetaryValue value1, double value2 )
		{
			return new MonetaryValue(value1.m_Value - value2);
		}

		public static MonetaryValue operator *( MonetaryValue value1, double value2 )
		{
			return new MonetaryValue(value1.m_Value * value2);
		}

		public static MonetaryValue operator /( MonetaryValue value1, double value2 )
		{
			return new MonetaryValue(value1.m_Value / value2);
		}

		#endregion
	}
}