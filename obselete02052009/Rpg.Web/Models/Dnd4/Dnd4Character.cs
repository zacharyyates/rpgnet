/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/6/2008
 */

using System.Collections.Generic;

namespace YatesMorrison.Rpg.Dnd4
{
	public class Dnd4Character : Character
	{
		public Dictionary<string, string> AbilityScoreNames
		{
			get
			{
				return new Dictionary<string, string> { 
					{"Str", "Strength"},
					{"Con", "Constitution"},
					{"Dex", "Dexterity"},
					{"Int", "Intelligence"},
					{"Wis", "Wisdom"},
					{"Cha", "Charisma"}
				};
			}
		}

		public Dictionary<string, string> Defenses
		{
			get
			{
				return new Dictionary<string, string> {
					{"AC", "Armor Class"},
					{"Fort", "Fortitude"},
					{"Ref", "Reflex"},
					{"Will", "Will"}
				};
			}
		}

		public List<string> SkillNames
		{
			get
			{
				return new List<string> { "Acrobatics", "Arcana", "Athletics", "Bluff", "Diplomacy", "Dungeoneering", 
					"Endurance", "Heal", "History", "Insight", "Intimidate", "Nature", "Perception", "Religion", "Stealth",
					"Streetwise", "Thievery" };
			}
		}

		public double AverageAbilityScore
		{
			get
			{
				double total = 0;
				foreach (string abbrv in AbilityScoreNames.Keys)
				{
					total += GetCalculatedScoreFor(abbrv);
				}
				return total / 6;
			}
		}
	}
}