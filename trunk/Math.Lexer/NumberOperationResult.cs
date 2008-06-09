/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public class NumberOperationResult : IOperationResult
	{
		public NumberOperationResult(double value)
		{
			m_Value = value;
		}

		#region IOperationResult Members

		public double Value
		{
			get { return m_Value; }
		}
		double m_Value = 0;

		#endregion
	}
}
