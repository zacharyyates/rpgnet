/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.RolePlay.Extensions
{
	using System;
	using System.Collections.Generic;

	[Serializable]
	public class CharacterTemplate // todo: Build a factory class that can use this to build a character
	{
		public string CharacterClassName { get; set; }

		public List<AttributeTemplate> AttributeTemplates
		{
			get { return m_AttributeTemplates; }
		}
		List<AttributeTemplate> m_AttributeTemplates = new List<AttributeTemplate>();

		public List<AttributeInstance> AttributeInstances
		{
			get { return m_AttributeInstances; }
		}
		List<AttributeInstance> m_AttributeInstances = new List<AttributeInstance>();
	}
}