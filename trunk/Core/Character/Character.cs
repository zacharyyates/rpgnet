/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.RolePlay
{
	public class Character : Actor
	{
		#region Derived Attributes

		// [ZLY 11.04.2007] I think all of the attributes here can be abstracted into an attribute class, 
		// then dependency injected into a character object at runtime to abstract the entire system from the rule set.
		// However, that would be out of scope for this project, so I leave it up to myself at a later date, 
		// or someone else all together...
		// Or maybe I'll just do it...
		// [ZLY 6.24.2008] I obviously did it already.

		#endregion

		public Inventory Inventory { get; set; }

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
			double simpleScore = GetSimpleScoreFor(attribute);
			if( m_Levels.Count > 1 )
			{
				if( m_Levels[0].IsActive )
				{
					return m_Levels[0].Attributes[attribute].GetCalculatedScore(simpleScore);
				}
			}
			
			// There should always be a level 1, but in case there isn't, send back the simpleScore
			return simpleScore;
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
			get { return m_Levels.Count; }
		}
	}
}