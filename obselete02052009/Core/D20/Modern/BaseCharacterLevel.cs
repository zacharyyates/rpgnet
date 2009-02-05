/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/10/2007
 */

namespace YatesMorrison.RolePlay.D20.Modern
{
	public class BaseCharacterLevel : CharacterLevel
	{
		public BaseCharacterLevel( Character character ) : base(character) 
		{
			LevelIndex = LevelsInClass + 1;
		}
		public BaseCharacterLevel( Character character, string className )
			: this(character)
		{
			ClassName = className;
		}

		public double AbilityScoreBonus
		{
			get { return m_AbilityScoreBonus; }
			set { m_AbilityScoreBonus = value; }
		}
		double m_AbilityScoreBonus = 0;

		public double SkillPoints
		{
			get { return m_SkillPoints; }
			set { m_SkillPoints = value; }
		}
		double m_SkillPoints = 0;

		public int Feats
		{
			get { return m_Feats; }
			set { m_Feats = value; }
		}
		int m_Feats = 0;

		public int BonusFeats
		{
			get { return m_BonusFeats; }
			set { m_BonusFeats = value; }
		}
		int m_BonusFeats = 0;

		public int Talents
		{
			get { return m_Talents; }
			set { m_Talents = value; }
		}
		int m_Talents = 0;

		public int LevelsInClass
		{
			get { return Character.GetLevelsFor(ClassName); }
		}
	}
}