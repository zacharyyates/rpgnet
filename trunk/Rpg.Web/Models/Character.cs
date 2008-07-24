/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/6/2008
 */

using System.Collections.Generic;
using System.Linq;

namespace YatesMorrison.Rpg
{
	public class Character : Actor
	{
		public string GivenName { get; set; }
		public string Surname { get; set; }
		public string CharacterClass { get; set; }
		public int Experience { get; set; }
		public string Race { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }

		public override string Name
		{
			get { return GivenName + " " + Surname; }
			set { base.Name = value; }
		}
		//public Inventory Inventory { get; set; }

		public List<CharacterLevel> Levels
		{
			get { return m_Levels; }
		}
		List<CharacterLevel> m_Levels = new List<CharacterLevel>();

		#region Effects

		public List<Effect> Effects
		{
			get { return m_Effects; }
		}
		List<Effect> m_Effects = new List<Effect>();

		public List<Effect> GetEffectsFor( string attribute )
		{
			List<Effect> effectList = new List<Effect>();

			foreach( Effect effect in m_Effects )
			{
				bool addToList = false;
				foreach( KeyValuePair<string, Modifier> modifier in effect.Modifiers )
				{
					if( modifier.Value.TargetAttribute == attribute )
					{
						addToList = true;
					}
				}

				if( addToList )
				{
					effectList.Add(effect);
				}
			}

			return effectList;
		}

		public double GetEffectModifierTotalFor( string attribute )
		{
			double total = 0;

			foreach( Effect effect in m_Effects )
			{
				if( effect.Modifiers.ContainsKey(attribute) )
				{
					Modifier modifier = effect.Modifiers[attribute];

					if( modifier != null )
					{
						total += modifier.GetBonus(this);
					}
				}
			}

			return total;
		}

		public double GetEffectedScoreFor( string attribute )
		{
			double score = GetCalculatedScoreFor(attribute);
			double modifier = GetEffectModifierTotalFor(attribute);
			return score + modifier;
		}

		#endregion

		#region Character Attributes

		#region DnD 4

		//public double Strength
		//{
		//    get { return GetSimpleScoreFor("Str"); }
		//}
		//public double Constitution
		//{
		//    get { return GetSimpleScoreFor("Con"); }
		//}
		//public double Dexterity
		//{
		//    get { return GetSimpleScoreFor("Dex"); }
		//}
		//public double Intelligence
		//{
		//    get { return GetSimpleScoreFor("Int"); }
		//}
		//public double Wisdom
		//{
		//    get { return GetSimpleScoreFor("Wis"); }
		//}
		//public double Charisma
		//{
		//    get { return GetSimpleScoreFor("Cha"); }
		//}

		#endregion

		public double GetSimpleScoreFor( string attribute )
		{
			double simpleScore = 0;

			foreach( CharacterLevel level in m_Levels )
			{
				if( level.Attributes.ContainsKey(attribute) && level.IsActive )
				{
					simpleScore += level.Attributes[attribute].SimpleScore;
				}
			}

			return simpleScore;
		}

		public double GetCalculatedScoreFor( string attribute )
		{
			if (HasAttribute(attribute))
			{
				double simpleScore = GetSimpleScoreFor(attribute);
				if (m_Levels.Count > 0)
				{
					if (m_Levels[0].IsActive)
					{
						return m_Levels[0].Attributes[attribute].GetCalculatedScore(simpleScore);
					}
				}

				// There should always be a level 1, but in case there isn't, send back the simpleScore
				return simpleScore;
			}
			else
			{
				return 0; // TODO: Should we return an error code here?
			}
		}

		public List<string> AttributeNames
		{
			get
			{
				List<string> names = new List<string>();
				foreach( CharacterLevel level in m_Levels )
				{
					foreach( KeyValuePair<string, CharacterAttribute> attribute in level.Attributes )
					{
						names.Add(attribute.Key);
					}
				}

				return names;
			}
		}

		public bool HasAttribute( string name )
		{
			foreach( CharacterLevel level in m_Levels )
			{
				if( level.Attributes.ContainsKey(name) )
				{
					return true;
				}
			}
			return false;
		}
		
		#endregion

		public int GetLevelsFor( string className )
		{
			int levels = 0;

			foreach( CharacterLevel level in m_Levels )
			{
				if( level.ClassName == className )
				{
					levels++;
				}
			}

			return levels;
		}

		public int CharacterLevel
		{
			get { return m_Levels.Count(l => l.IsActive); }
		}
	}
}