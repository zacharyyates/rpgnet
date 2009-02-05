/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

using System;
using System.Collections.Generic;

namespace YatesMorrison.Math.Lexer
{
	public interface IExpressionFactory
	{
		IExpression Create(string token);
	}

	public class ExpressionFactory : IExpressionFactory
	{
		/// <summary>
		/// Private constructor
		/// </summary>
		ExpressionFactory() { }	

		/// <summary>
		/// TODO: Load this class from app.config
		/// </summary>
		public static IExpressionFactory CreateInstance()
		{
			return new ExpressionFactory();
		}

		public IExpression Create(string token)
		{
			return Create(Split(token));
		}

		public IExpression Create(List<string> tokens)
		{
			IExpression expression = null;

			// Value expression
			if (tokens.Count == 1)
			{
				expression = CreateValueExpression(tokens[0]);
			}

			// If there are at least 3 subtokens, we have a full operationExpression
			if (tokens.Count >= 3)
			{
				expression = CreateOperationExpression(tokens.GetRange(0, 3));
			}

			return expression;
		}

		IExpression CreateOperationExpression(List<string> tokens)
		{
			// Assuming leftOperand operator rightOperand
			OperationExpression operationExpression = new OperationExpression();
			operationExpression.LeftOperand = Create(tokens[0]);
			operationExpression.Operator = OperatorFactory.CreateInstance().Create(tokens[1]);
			operationExpression.RightOperand = Create(tokens[2]);

			return operationExpression;
		}

		IExpression CreateValueExpression(string token)
		{
			ValueExpression valueExpression = new ValueExpression();
			valueExpression.FromString(token);
			return valueExpression;
		}		
	}
}