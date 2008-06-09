/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/20/2007
 */

namespace YatesMorrison.RolePlay.D20.Modern
{
	public class CharacterLevelFactoryConfiguration
	{
		public string ClassName
		{
			get { return m_ClassName; }
			set { m_ClassName = value; }
		}
		string m_ClassName = string.Empty;

		public string HitDie
		{
			get { return m_HitDie; }
			set { m_HitDie = value; }
		}
		string m_HitDie = "1d6";

		public double SkillPointsPerLevel
		{
			get { return m_SkillPointsPerLevel; }
			set { m_SkillPointsPerLevel = value; }
		}
		double m_SkillPointsPerLevel = 0;

		public Progression FortitudeSave
		{
			get { return m_FortitudeSave; }
			set { m_FortitudeSave = value; }
		}
		Progression m_FortitudeSave = null;

		public Progression ReflexSave
		{
			get { return m_ReflexSave; }
			set { m_ReflexSave = value; }
		}
		Progression m_ReflexSave = null;

		public Progression WillSave
		{
			get { return m_WillSave; }
			set { m_WillSave = value; }
		}
		Progression m_WillSave = null;

		public Progression AttackBonus
		{
			get { return m_AttackBonus; }
			set { m_AttackBonus = value; }
		}
		Progression m_AttackBonus = null;

		public Progression DefenseBonus
		{
			get { return m_DefenseBonus; }
			set { m_DefenseBonus = value; }
		}
		Progression m_DefenseBonus = null;

		public Progression ReputationBonus
		{
			get { return m_ReputationBonus; }
			set { m_ReputationBonus = value; }
		}
		Progression m_ReputationBonus = null;
	}
}