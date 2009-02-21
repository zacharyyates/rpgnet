/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;

	public class MvcLink : MvcControl
	{
		private string Uri
		{
			set { Attributes.Merge("href", value); }
		}

		public MvcLink(string text, string uri)
			: base("a")
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Value cannot be null or empty.", "text");
			}

			if (string.IsNullOrEmpty(uri))
			{
				throw new ArgumentException("Value cannot be null or empty.", "uri");
			}

			SetInnerText(text);

			Uri = uri;
		}
	}
}