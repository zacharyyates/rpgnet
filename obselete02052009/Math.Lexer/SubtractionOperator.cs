/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public class SubtractionOperator :
		IBinaryOperator
	{
		#region IOperator Members

		public double Evaluate(IExpression leftOperand, IExpression rightOperand)
		{
			return leftOperand.Evaluate() - rightOperand.Evaluate();
		}

		#endregion

		#region IToken Members

		public void FromString(string token) { }

		#endregion
	}
}