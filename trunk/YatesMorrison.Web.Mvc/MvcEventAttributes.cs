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

	public abstract class MvcEventAttributes : MvcControl
	{
		public string OnBlur
		{
			set { AddEventScript("onblur", value); }
		}

		public string OnClick
		{
			set { AddEventScript("onclick", value); }
		}

		public string OnDoubleClick
		{
			set { AddEventScript("ondblclick", value); }
		}

		public string OnFocus
		{
			set { AddEventScript("onfocus", value); }
		}

		public string OnKeyDown
		{
			set { AddEventScript("onkeydown", value); }
		}

		public string OnKeyPress
		{
			set { AddEventScript("onkeypress", value); }
		}

		public string OnKeyUp
		{
			set { AddEventScript("onkeyup", value); }
		}

		public string OnMouseDown
		{
			set { AddEventScript("onmousedown", value); }
		}

		public string OnMouseMove
		{
			set { AddEventScript("onmousemove", value); }
		}

		public string OnMouseOver
		{
			set { AddEventScript("onmouseover", value); }
		}

		public string OnMouseOut
		{
			set { AddEventScript("onmouseout", value); }
		}

		public string OnMouseUp
		{
			set { AddEventScript("style", value); }
		}

		public MvcEventAttributes(string tagName)
			: base(tagName) { }

		public MvcEventAttributes(string tagName, TagRenderMode tagRenderMode)
			: base(tagName, tagRenderMode) { }
	}
}