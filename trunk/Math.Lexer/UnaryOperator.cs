/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public interface IUnaryOperator
	{
		IExpression Evaluate(IExpression operand);
	}
}