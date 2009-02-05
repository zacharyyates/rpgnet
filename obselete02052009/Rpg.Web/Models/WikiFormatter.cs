/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/20/2008 9:27
 */

using System.Text.RegularExpressions;
using System.Text;

namespace Rpg.Web.Models
{
	public class WikiFormatter
	{
		public string Format(string content)
		{
			// match bold rule

			content = ReplaceBold(content);
			content = ReplaceItalics(content);

			return content;
		}

		static string ReplaceBold(string input)
		{
			return Replace(input, @"'''", @"<b>", @"'''", @"</b>");
		}

		static string ReplaceItalics(string input)
		{
			return Replace(input, @"''", @"<i>", @"''", @"</i>");
		}

		static string Replace(string input, string startOriginal, string startReplacement, string endOriginal, string endReplacement)
		{
			Regex regex = new Regex(startOriginal + @".*" + endOriginal);
			string output = regex.Replace(input, delegate(Match match)
			{
				string token = match.Value.Substring(startOriginal.Length);
				token = token.Substring(0, token.Length - endOriginal.Length);
				return startReplacement + token + endReplacement;
			});

			return output;
		}
	}
}