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
			Character = character;
		}

		public string ClassName { get; set; }
		public int LevelIndex { get; set; }
		public Character Character { get; set; }
		public bool IsActive { get; set; }

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