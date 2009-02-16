/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison
{
	using System;

	public static class StringExtensions
	{
		public static bool EqualsIgnoreCase(this string str1, string value)
		{
			return str1.Equals(value, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}