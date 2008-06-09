/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.RolePlay
{
	public class CharacterLevel
	{
		public CharacterLevel( Character character )
		{
			m_Character = character;
		}

		public string ClassName
		{
			get { return m_ClassName; }
			set { m_ClassName = value; }
		}
		string m_ClassName = string.Empty;

		public int LevelIndex
		{
			get { return m_LevelIndex; }
			set { m_LevelIndex = value; }
		}
		int m_LevelIndex = 0;

		public Character Character
		{
			get { return m_Character; }
			set { m_Character = value; }
		}
		Character m_Character = null;

		public bool IsActive
		{
			get { return m_IsActive; }
			set { m_IsActive = value; }
		}
		bool m_IsActive = true;

		public void AddAttribute( CharacterAttribute attribute )
		{
			if (Attributes.ContainsKey(attribute.Name))
			{
				Attributes[attribute.Name].SimpleScore += attribute.SimpleScore;
			}
			else
			{
				Attributes.Add(attribute.Name, attribute);
			}
		}

		public Dictionary<string, CharacterAttribute> Attributes
		{
			get { return m_Attributes; }
		}
		Dictionary<string, CharacterAttribute> m_Attributes = new Dictionary<string, CharacterAttribute>();

		public void AddEnhancement( CharacterEnhancement enchancement )
		{
			Enhancements.Add(enchancement.Name, enchancement);
		}

		public Dictionary<string, CharacterEnhancement> Enhancements
		{
			get { return m_Enhancements; }
		}
		Dictionary<string, CharacterEnhancement> m_Enhancements = new Dictionary<string, CharacterEnhancement>();
	}
}