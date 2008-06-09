/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.Math.Lexer
{
	public interface IToken
	{
		void FromString(IToken parent, string token);
		IList<IToken> Children { get; }
	}
}