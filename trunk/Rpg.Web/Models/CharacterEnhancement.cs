/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.Rpg
{
	public class CharacterEnhancement
	{
		public string Name { get; set; }
		
		public List<Modifier> Modifiers
		{
			get { return m_Modifiers; }
			set { m_Modifiers = value; }
		}
		List<Modifier> m_Modifiers = new List<Modifier>();

		public List<IRequisite> Requisites
		{
			get { return m_Requisites; }
			set { m_Requisites = value; }
		}
		List<IRequisite> m_Requisites = new List<IRequisite>();
	}
}