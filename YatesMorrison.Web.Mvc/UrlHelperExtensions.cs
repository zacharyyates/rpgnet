/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System;
	using System.Globalization;
	using System.Web.Mvc;
	using System.Web.Routing;

	// These methods have been copied from the ASP.NET MVC Beta source code.
	// They were originally declared with the "internal" keyword.
	public static class UrlHelperExtensions
	{
		public static string GenerateUrl(this UrlHelper urlHelper, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary values)
		{
			string url = GenerateUrl(urlHelper, routeName, actionName, controllerName, values);

			if (url != null)
			{
				if (!string.IsNullOrEmpty(fragment))
				{
					url = url + "#" + fragment;
				}

				if (!string.IsNullOrEmpty(protocol) || !string.IsNullOrEmpty(hostName))
				{
					Uri requestUrl = urlHelper.RequestContext.HttpContext.Request.Url;

					protocol = !string.IsNullOrEmpty(protocol) ? protocol : Uri.UriSchemeHttp;
					hostName = !string.IsNullOrEmpty(hostName) ? hostName : requestUrl.Host;

					string port = string.Empty;
					string requestProtocol = requestUrl.Scheme;

					if (string.Equals(protocol, requestProtocol, StringComparison.OrdinalIgnoreCase))
					{
						port = requestUrl.IsDefaultPort ? string.Empty : ":" + Convert.ToString(requestUrl.Port, CultureInfo.CurrentUICulture);
					}

					url = protocol + Uri.SchemeDelimiter + hostName + port + url;
				}
			}

			return url;
		}

		public static string GenerateUrl(this UrlHelper urlHelper, string routeName, string actionName, string controllerName, RouteValueDictionary values)
		{
			if (actionName != null)
			{
				if (values.ContainsKey("action"))
				{
					string message = "The provided object or dictionary already contains a definition for 'action'.";

					throw new ArgumentException(message, "actionName");
				}

				values.Add("action", actionName);
			}

			if (controllerName != null)
			{
				if (values.ContainsKey("controller"))
				{
					string message = "The provided object or dictionary already contains a definition for 'controller'.";

					throw new ArgumentException(message, "controllerName");
				}

				values.Add("controller", controllerName);
			}

			VirtualPathData virtualPathData;

			if (routeName != null)
			{
				virtualPathData = urlHelper.RouteCollection.GetVirtualPath(urlHelper.RequestContext, routeName, values);
			}
			else
			{
				virtualPathData = urlHelper.RouteCollection.GetVirtualPath(urlHelper.RequestContext, values);
			}

			if (virtualPathData != null)
			{
				return virtualPathData.VirtualPath;
			}

			return null;
		}
	}
}
