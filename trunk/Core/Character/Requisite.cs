/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/5/2007
 */

using System;
namespace YatesMorrison.RolePlay
{
	public interface IRequisite
	{
		string AttributeName { get; set; }
		bool Meets( ref Character character );
	}

	public abstract class BaseRequisite : IRequisite
	{
		string IRequisite.AttributeName
		{
			get { return m_AttributeName; }
			set { m_AttributeName = value; }
		}
		protected string m_AttributeName = string.Empty;

		public abstract bool Meets(ref Character character );
	}

	public class NumericRequisite : BaseRequisite
	{
		public override bool Meets( ref Character character )
		{
			try
			{
				double attribVal = (double)character.GetEffectedScoreFor(m_AttributeName);

				switch( m_Operator )
				{
					case NumericComparisonOperator.EqualTo: return ( m_Value == attribVal );
					case NumericComparisonOperator.GreaterThan: return ( m_Value > attribVal );
					case NumericComparisonOperator.GreaterThanOrEqualTo: return ( m_Value >= attribVal );
					case NumericComparisonOperator.LessThan: return ( m_Value < attribVal );
					case NumericComparisonOperator.LessThanOrEqaualTo: return ( m_Value <= attribVal );
					
					default: return false;
				}
			}
			catch( Exception exception )
			{
				throw new InvalidOperationException(string.Format(
						"The attribute \"{0}\" was not found on the character \"{1}\".", m_AttributeName, character.Name), exception);
			}
		}

		public NumericComparisonOperator Operator
		{
			get { return m_Operator; }
			set { m_Operator = value; }
		}
		NumericComparisonOperator m_Operator;

		public double Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		double m_Value = 0;
	}

	public class HasAttributeRequisite : BaseRequisite
	{
		public override bool Meets( ref Character character )
		{
			return character.HasAttribute(m_AttributeName);
		}
	}

	public enum NumericComparisonOperator
	{
		LessThan,
		LessThanOrEqaualTo,
		EqualTo,
		GreaterThanOrEqualTo,
		GreaterThan
	}
}