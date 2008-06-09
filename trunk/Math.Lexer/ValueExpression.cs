/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

using System;

namespace YatesMorrison.Math.Lexer
{
	public class ValueExpression : IExpression
	{
		double m_Value = 0;

		#region IToken Members

		public void FromString(string token)
		{
			token = token.Trim();
			m_Value = Convert.ToDouble(token);
		}

		#endregion

		#region IExpression Members

		public double Evaluate()
		{
			return m_Value;
		}

		#endregion
	}
}