using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YatesMorrison.Math.Lexer
{
	class AdditionExpression : IExpression
	{
		#region IExpression Members

		public IResult Evaluate()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IToken Members

		public override void FromString(IToken parent, string token)
		{
			if( 
		}

		public IList<IToken> Children
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
