/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace YatesMorrison.Rpg
{
	public class Effect
	{
		public string Name { get; set; }

		public Dictionary<string, Modifier> Modifiers
		{
			get { return m_Modifiers; }
		}
		Dictionary<string, Modifier> m_Modifiers = new Dictionary<string, Modifier>();
	}

	public class EffectCollection : Collection<Effect>
	{
		public EffectCollection GetEffectsFor(string attribute)
		{
			EffectCollection effectList = new EffectCollection();

			foreach (Effect effect in this)
			{
				bool addToList = false;
				foreach (KeyValuePair<string, Modifier> modifier in effect.Modifiers)
				{
					if (modifier.Value.TargetAttribute == attribute)
					{
						addToList = true;
					}
				}

				if (addToList)
				{
					effectList.Add(effect);
				}
			}

			return effectList;
		}

		
	}
}