/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

using System.Collections.Generic;
namespace YatesMorrison.Math.Lexer
{
	public class BinaryExpression : BaseToken
	{
		public override void FromString(IToken parent, string token)
		{
			List<string> subtokens = Split(token);

			if (subtokens.Count >= 3) // leftOperand operator rightOperand
			{

			}
		}
	}
}