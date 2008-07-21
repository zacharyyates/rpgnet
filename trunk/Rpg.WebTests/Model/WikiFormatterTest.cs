using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rpg.Web.Models;

namespace Rpg.WebTests
{
	[TestClass]
	public class WikiFormatterTest
	{
		[TestMethod]
		public void TestBold()
		{
			WikiFormatter formatter = new WikiFormatter();
			string innerText = "Hi you freako";
			string expected = @"<b>" + innerText + @"</b>";
			string actual = formatter.Format(@"'''" + innerText + @"'''");

			Assert.AreEqual<string>(expected, actual);
		}

		[TestMethod]
		public void TestItalics()
		{
			WikiFormatter formatter = new WikiFormatter();
			string innerText = "Hi you freako";
			string expected = @"<i>" + innerText + @"</i>";
			string actual = formatter.Format(@"''" + innerText + @"''");

			Assert.AreEqual<string>(expected, actual);
		}
	}
}