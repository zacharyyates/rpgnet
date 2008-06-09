/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public class OperationExpression : 
		IExpression, IOperation
	{
		#region IExpression Members

		public IExpression LeftOperand
		{
			get { return m_LeftOperand; }
			set { m_LeftOperand = value; }
		}
		IExpression m_LeftOperand = null;

		public IExpression RightOperand
		{
			get { return m_RightOperand; }
			set { m_RightOperand = value; }
		}
		IExpression m_RightOperand = null;

		public IBinaryOperator Operator
		{
			get { return m_Operator; }
			set { m_Operator = value; }
		}
		IBinaryOperator m_Operator = null;

		#endregion

		#region IExpression Members

		public double Evaluate()
		{
			return Operator.Evaluate(LeftOperand, RightOperand);
		}

		#endregion

		#region IToken Members

		public void FromString(string expression)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}