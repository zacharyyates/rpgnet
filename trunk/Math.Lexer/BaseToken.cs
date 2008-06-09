/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

using System;
using System.Collections.Generic;

namespace YatesMorrison.Math.Lexer
{
	public abstract class BaseToken : IToken
	{
		#region IToken Members

		public abstract void FromString(IToken parent, string token);

		public IList<IToken> Children
		{
			get { return m_Children; }
		}
		IList<IToken> m_Children = new List<IToken>();

		protected List<string> Split(string token)
		{
			return new List<string>(
				token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
		}

		#endregion
	}
}