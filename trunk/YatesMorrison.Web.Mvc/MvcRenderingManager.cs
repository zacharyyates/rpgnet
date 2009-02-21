/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System.Collections.Generic;
	using System.Web.Mvc;
	using YatesMorrison.UI;

	public class MvcRenderingManager : IRenderingManager
	{
		public MvcRenderingManager(IList<IControl> controls, HtmlHelper htmlHelper)
		{
			m_Controls = controls;
			m_HtmlHelper = htmlHelper;
		}

		public IList<IControl> Controls
		{
			get { return m_Controls; }
		}
		IList<IControl> m_Controls = new List<IControl>();

		HtmlHelper m_HtmlHelper;

		public void Render()
		{
			// todo: code up some sort of default layout manager
			foreach (var control in Controls)
			{
				MvcControl mvcControl = control as MvcControl;
				if (mvcControl != null)
				{
					var response = m_HtmlHelper.ViewContext.HttpContext.Response; 
					response.Write(mvcControl.Html(m_HtmlHelper.ViewContext)); // oh my shitballs it worked
				}
			}
		}
	}
}