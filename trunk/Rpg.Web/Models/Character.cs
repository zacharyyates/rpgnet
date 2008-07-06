/* Zachary Yates
 * 2007 © YatesMorrison Software Company
 * 7/6/2008
 */

using System;
using System.Collections.Generic;

namespace YatesMorrison.Rpg
{
	public class Character : Actor
	{
		public int ExperiencePoints { get; set; }
		public int CharacterLevel { get; set; }
		public int ExperienceLevel
		{
			get
			{
				int? level = m_ExperienceProgression.GetIndex(ExperiencePoints);
				if (level.HasValue)
					return level.Value;
				else
					return 0;
			}
		}

		// 4th Ed experience progression
		Progression m_ExperienceProgression = new Progression(
			0, 1000, 2250, 3750, 5500, 7500, 10000, 13000, 16500, 20500,
			26000, 32000, 39000, 47000, 57000, 69000, 83000, 99000, 119000, 143000,
			175000, 210000, 255000, 310000, 375000, 450000, 550000, 675000, 825000, 1000000);

		#region Effects

		public EffectCollection Effects
		{
			get { return m_Effects; }
		}
		EffectCollection m_Effects = new EffectCollection();

		public double GetEffectModifierTotalFor(string attribute)
		{
			double total = 0;

			foreach (Effect effect in Effects)
			{
				if (effect.Modifiers.ContainsKey(attribute))
				{
					Modifier modifier = effect.Modifiers[attribute];

					if (modifier != null)
					{
						total += modifier.GetBonus(this);
					}
				}
			}

			return total;
		}

		public double GetEffectedScoreFor(string attribute)
		{
			double score = GetCalculatedScoreFor(attribute);
			double modifier = GetEffectModifierTotalFor(attribute);
			return score + modifier;
		}

		#endregion

		#region Character Attributes

		public Dictionary<string, CharacterAttribute> Attributes
		{
			get { return m_Attributes; }
		}
		Dictionary<string, CharacterAttribute> m_Attributes = new Dictionary<string, CharacterAttribute>();

		public double GetCalculatedScoreFor(string attribute)
		{
			if (Attributes.ContainsKey(attribute))
			{
				return Attributes[attribute].CalculatedScore;
			}
			throw new InvalidOperationException(attribute + " is not an attribute on " + this.Name);
		}

		public List<string> AttributeNames
		{
			get
			{
				List<string> names = new List<string>();
				foreach (KeyValuePair<string, CharacterAttribute> attribute in Attributes)
				{
					names.Add(attribute.Key);
				}
				return names;
			}
		}

		public bool HasAttribute(string name)
		{
			if (Attributes.ContainsKey(name))
			{
				return true;
			}
			return false;
		}

		#endregion

		#region Enhancements

		public Dictionary<string, CharacterEnhancement> Enhancements
		{
			get { return m_Enhancements; }
		}
		Dictionary<string, CharacterEnhancement> m_Enhancements = new Dictionary<string, CharacterEnhancement>();

		#endregion
	}
}