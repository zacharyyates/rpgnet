/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

using System;

namespace YatesMorrison.Math.Lexer
{
	public class OperatorFactory
	{
		/// <summary>
		/// Private constructor
		/// </summary>
		OperatorFactory() { }

		public static OperatorFactory CreateInstance()
		{
			return new OperatorFactory(); 
		}

		public virtual IBinaryOperator Create(string token)
		{
			switch (token.Trim())
			{
				case "+": return new AdditionOperator();
				case "-": return new SubtractionOperator();
				case "*": return new MultiplicationOperator();
				case "/": return new DivisionOperator();

				default: return null;
			}
		}

		public virtual int GetRank(string token)
		{
			switch (token.Trim())
			{
				case "(":
				case ")": return 0;

				case "^": return 1;

				case "*":
				case "/": return 2;

				case "+": 
				case "-": return 3;

				default: return -1;
			}
		}
	}
}