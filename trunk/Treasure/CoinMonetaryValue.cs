/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/22/2008
 */

namespace YatesMorrison.RolePlay.D20.Past
{
	public class CoinMonetaryValue : MonetaryValue
	{
		public CoinMonetaryValue( CoinType type, double value )
		{
			Type = type;
			Value = value;
		}
		public CoinMonetaryValue( CoinType type, int? value ) : this(type, (double)value) { }
		public CoinMonetaryValue( CoinType type, int value ) : this(type, (double)value) { }
		public CoinMonetaryValue( CoinType type, double? value ) : this(type, (double)value) { }

		public CoinType Type
		{
			get { return m_Type; }
			set { m_Type = value; }
		}
		CoinType m_Type = CoinType.Gold;

		public override double Value
		{
			get
			{
				switch( m_Type )
				{
					case CoinType.Copper: return (m_Value * 100);
					case CoinType.Silver: return (m_Value * 10);
					default:
					case CoinType.Gold: return (m_Value);
					case CoinType.Platinum: return (m_Value * 0.1);
				}
			}
			set
			{
				switch( m_Type )
				{
					case CoinType.Copper: m_Value = value * 0.01; break;
					case CoinType.Silver: m_Value = value * 0.1; break;
					default:
					case CoinType.Gold: m_Value = value; break;
					case CoinType.Platinum: m_Value = value * 10; break;
				}
			}
		}

		public override string GetDebugString()
		{
			string text = Value + " ";
			switch( Type )
			{
				case CoinType.Copper: text += "cp"; break;
				case CoinType.Silver: text += "sp"; break;
				default:
				case CoinType.Gold: text += "gp"; break;
				case CoinType.Platinum: text += "pp"; break;
			}
			return text;
		}

		#region Operators

		public static CoinMonetaryValue operator +( CoinMonetaryValue value1, CoinMonetaryValue value2 )
		{
			// Convert both to gold
			value1.Type = CoinType.Gold;
			value2.Type = CoinType.Gold;
			return new CoinMonetaryValue(CoinType.Gold, value1.Value + value2.Value);
		}

		public static CoinMonetaryValue operator -( CoinMonetaryValue value1, CoinMonetaryValue value2 )
		{
			// Convert both to gold
			value1.Type = CoinType.Gold;
			value2.Type = CoinType.Gold;
			return new CoinMonetaryValue(CoinType.Gold, value1.Value - value2.Value);
		}

		public static CoinMonetaryValue operator +( CoinMonetaryValue value1, double value2 )
		{
			return new CoinMonetaryValue(value1.Type, value1.Value + value2);
		}

		public static CoinMonetaryValue operator -( CoinMonetaryValue value1, double value2 )
		{
			return new CoinMonetaryValue(value1.Type, value1.Value - value2);
		}

		public static CoinMonetaryValue operator *( CoinMonetaryValue value1, double value2 )
		{
			value1.Type = CoinType.Gold;
			return new CoinMonetaryValue(CoinType.Gold, value1.Value * value2);
		}

		public static CoinMonetaryValue operator /( CoinMonetaryValue value1, double value2 )
		{
			value1.Type = CoinType.Gold;
			return new CoinMonetaryValue(CoinType.Gold, value1.Value / value2);
		}

		#endregion
	}

	public enum CoinType
	{
		Nothing = 0,
		Copper = 1,
		Silver = 2,
		Gold = 3,
		Platinum = 4
	}
}