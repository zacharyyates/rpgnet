/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * @source http://www.codeproject.com/KB/custom-controls/MVCCustomControls.aspx
 * @author Andrew Gunn
 * 2.20.2009
 */
namespace YatesMorrison.Web.Mvc
{
	using System.Web.Mvc;

	public static class ModelStateDictionaryExtensions
	{
		public static ModelErrorCollection GetErrors(this ModelStateDictionary modelStateDictionary, string modelName)
		{
			ModelErrorCollection modelErrors = null;
			ModelState modelState;

			if (modelStateDictionary.TryGetValue(modelName, out modelState))
			{
				modelErrors = modelState.Errors;
			}

			return modelErrors;
		}
	}
}