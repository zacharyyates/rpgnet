/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/10/2007
 */

using YatesMorrison.Math.Eval;

namespace YatesMorrison.RolePlay
{
	public static class RollHelper
	{
		public static double Roll( string function )
		{
			return new ExpressionParser(function).Eval();
		}
	}
}