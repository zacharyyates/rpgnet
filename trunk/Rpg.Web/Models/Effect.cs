/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.Rpg
{
	public class Effect
	{
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
		string m_Name = string.Empty;

		public Dictionary<string, Modifier> Modifiers
		{
			get { return m_Modifiers; }
		}
		Dictionary<string, Modifier> m_Modifiers = new Dictionary<string, Modifier>();
	}
}