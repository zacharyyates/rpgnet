/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using System.IO;
	using System.Web.Mvc;
	using System.Web.Routing;

	public class MvcBeginForm : MvcControl
	{
		#region MvcControlBuilder Members

		protected override void Initialise(ViewContext viewContext)
		{
			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			UrlHelper urlHelper = new UrlHelper(new RequestContext(viewContext.HttpContext, viewContext.RouteData));
			Attributes.Merge("action", urlHelper.GenerateUrl(null /* routeName */, ActionName, ControllerName, new RouteValueDictionary(Values)));
		}

		#endregion

		public string Action
		{
			set { Attributes.Merge("action", value); }
		}

		public string ActionName { protected get; set; }

		public string ControllerName { protected get; set; }

		public FormMethod Method
		{
			set { Attributes.Merge("method", HtmlHelper.GetFormMethodString(value)); }
		}

		public object Values { protected get; set; }

		public MvcBeginForm()
			: base("form", TagRenderMode.StartTag)
		{
			Method = FormMethod.Post;
		}
	}
}