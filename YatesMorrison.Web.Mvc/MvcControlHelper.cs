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

	public static class MvcControlHelper
	{
		public static InputType GetInputTypeEnum(object type)
		{
			if (type == null) { throw new ArgumentNullException("type"); }
			return GetInputTypeEnum(type.ToString());
		}

		public static InputType GetInputTypeEnum(string type)
		{
			if (string.IsNullOrEmpty(type))	{ throw new ArgumentException("Value cannot be null or empty.", "type"); }

			switch (type.ToLowerInvariant())
			{
				case "checkbox":	return InputType.CheckBox;
				case "hidden":		return InputType.Hidden;
				case "password":	return InputType.Password;
				case "radio":		return InputType.RadioButton;
				case "submit":		return InputType.Submit;
				case "text":		return InputType.Text;
				default: throw new InvalidInputTypeException();
			}
		}

		public static string GetInputTypeString(InputType type)
		{
			switch (type)
			{
				case InputType.CheckBox:	return "checkbox";
				case InputType.Hidden:		return "hidden";
				case InputType.Password:	return "password";
				case InputType.RadioButton:	return "radio";
				case InputType.Submit:		return "submit";
				case InputType.Text:		return "text";
				default: throw new NotImplementedException();
			}
		}

		public static string GetScriptTypeString(ScriptType type)
		{
			switch (type)
			{
				case ScriptType.JavaScript: return "text/javascript";
				default: throw new NotImplementedException();
			}
		}

		public static void RenderWatermarkScript(StringWriter writer, ViewContext viewContext, string controlID, string modelName, string watermarkCssClass, string watermarkText)
		{
			if (writer == null) { throw new ArgumentNullException("writer"); }
			if (viewContext == null) { throw new ArgumentNullException("viewContext"); }

			ViewDataDictionary viewData = viewContext.ViewData;

			if (viewData == null) { throw new ArgumentNullException("viewData"); }

			if (!string.IsNullOrEmpty(controlID)
				&& !string.IsNullOrEmpty(watermarkCssClass)
				&& !string.IsNullOrEmpty(watermarkText))
			{
				ModelErrorCollection modelErrors = viewData.ModelState.GetErrors(modelName);

				if ((modelErrors == null || modelErrors.Count == 0))
				{
					string innerHtml = "$(function(){$('#" + controlID + "').addWatermark('" + watermarkCssClass + "', '" + watermarkText + "');});";
					MvcScript watermarkScript = new MvcScript(ScriptType.JavaScript, innerHtml);
					writer.Write(watermarkScript.Html(viewContext));
				}
			}
		}
	}
}