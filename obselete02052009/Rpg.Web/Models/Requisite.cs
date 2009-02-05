/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/5/2007
 */

using System;

namespace YatesMorrison.Rpg
{
	public interface IRequisite
	{
		string AttributeName { get; set; }
		bool Meets( ref Character character );
	}

	public abstract class BaseRequisite : IRequisite
	{
		public string AttributeName { get; set; }
		public abstract bool Meets(ref Character character );
	}

	public class NumericRequisite : BaseRequisite
	{
		public NumericComparisonOperator Operator { get; set; }
		public double Value { get; set; }

		public override bool Meets( ref Character character )
		{
			try
			{
				double attribVal = (double)character.GetEffectedScoreFor(AttributeName);

				switch( Operator )
				{
					case NumericComparisonOperator.EqualTo: return ( Value == attribVal );
					case NumericComparisonOperator.NotEqualTo: return ( Value != attribVal );
					case NumericComparisonOperator.GreaterThan: return ( Value > attribVal );
					case NumericComparisonOperator.GreaterThanOrEqualTo: return ( Value >= attribVal );
					case NumericComparisonOperator.LessThan: return ( Value < attribVal );
					case NumericComparisonOperator.LessThanOrEqaualTo: return ( Value <= attribVal );
					
					default: return false;
				}
			}
			catch( Exception exception )
			{
				throw new InvalidOperationException(string.Format(
						"The attribute \"{0}\" was not found on the character \"{1}\".", AttributeName, character.GivenName), exception);
			}
		}
	}

	public class HasAttributeRequisite : BaseRequisite
	{
		public override bool Meets( ref Character character )
		{
			return character.HasAttribute(AttributeName);
		}
	}

	public enum NumericComparisonOperator
	{
		LessThan,
		LessThanOrEqaualTo,
		EqualTo,
		NotEqualTo,
		GreaterThanOrEqualTo,
		GreaterThan
	}
}