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

	public class MvcScript : MvcControl
	{
		protected ScriptType Type
		{
			set { Attributes.Merge("type", MvcControlHelper.GetScriptTypeString(value)); }
		}

		public MvcScript(ScriptType type, string innerHtml)
			: base("script")
		{
			InnerHtml = innerHtml;
			Type = type;
		}
	}
}