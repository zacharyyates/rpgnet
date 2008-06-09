/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

namespace YatesMorrison.Math.Lexer
{
	public static class ExpressionHelper
	{
		public static double Evaluate(string expression)
		{
			return ExpressionFactory.CreateInstance().Create(expression).Evaluate();
		}
	}
}