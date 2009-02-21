/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using System.Web.Mvc;

	public static class HtmlHelperExtensions
	{
		public static string MvcControl(this HtmlHelper htmlHelper, MvcControl mvcControl)
		{
			if (mvcControl == null)
			{
				throw new ArgumentNullException("control");
			}

			return mvcControl.Html(htmlHelper.ViewContext);
		}
	}
}