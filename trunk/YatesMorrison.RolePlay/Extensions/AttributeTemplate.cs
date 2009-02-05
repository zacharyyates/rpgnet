/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.RolePlay.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	[Serializable]
	public class AttributeTemplate
	{
		public string AttributeClassName { get; set; }
		public string BaseFormula { get; set; }

		string TranslateSymbols(IDictionary<string, string> attributes)
		{
			if (!string.IsNullOrEmpty(BaseFormula))
			{
				StringBuilder output = new StringBuilder(BaseFormula);
				if (attributes != null)
				{
					foreach (var attrib in attributes)
					{
						output.Replace(attrib.Key, "Character.GetAttributeByName(" + attrib.Key + ").Total");
						output.Replace(attrib.Value, "Character.GetAttributeByAbbreviation(" + attrib.Value + ").Total");
					}
				}
				return output.ToString();
			}
			return BaseFormula;
		}

		public string GetSource(IDictionary<string, string> attributes)
		{
			string translated = TranslateSymbols(attributes);
			StringBuilder output = new StringBuilder();
			output.Append(
				@"	namespace YatesMorrison.RolePlay { 
						using System;
						public class " + AttributeClassName + @" : Attribute {
							public override double Base {
								get { return " + translated + @"; }
							}
						}
					}");
			return output.ToString();
		}
	}
}