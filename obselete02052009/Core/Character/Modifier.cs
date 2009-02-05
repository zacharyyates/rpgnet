/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

namespace YatesMorrison.RolePlay
{
	//public interface IModifier
	//{
	//    string TargetAttribute { get; set; }
		
	//    /// <summary>
	//    /// When implemented in a derived class, returns the modifier value, such as +1 or -2, not the entire calculated score.
	//    /// </summary>
	//    double GetBonus( Character character );
	//}

	public class Modifier // : IModifier
	{
		public string TargetAttribute
		{
			get { return m_TargetAttribute; }
			set { m_TargetAttribute = value; }
		}
		protected string m_TargetAttribute = string.Empty;

		public Operator Operator
		{
			get { return m_Operator; }
			set { m_Operator = value; }
		}
		Operator m_Operator;

		public double Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		double m_Value = 0;
		
		public double GetBonus( Character character )
		{
			double originalValue = character.GetEffectedScoreFor(TargetAttribute);
			double value = originalValue;

			switch( Operator )
			{
				case Operator.Add: value += m_Value; break;
				case Operator.Multiply: value *= m_Value; break;
				case Operator.Subtract: value -= m_Value; break;
				case Operator.Divide: value /= m_Value; break;

				default: break;
			}

			return originalValue - value;
		}
	}

	public enum Operator
	{
		Add,
		Subtract,
		Multiply,
		Divide
	}
}