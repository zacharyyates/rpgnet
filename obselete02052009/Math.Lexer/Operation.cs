/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public interface IOperation
	{
		IExpression LeftOperand { get; set; }
		IExpression RightOperand { get; set; }
		IBinaryOperator Operator { get; set; }
	}
}
