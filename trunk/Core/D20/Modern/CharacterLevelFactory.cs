/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/10/2007
 */

using System;
using System.Xml.Serialization;
using System.IO;

namespace YatesMorrison.RolePlay.D20.Modern
{
	public class CharacterLevelFactory : ICharacterLevelFactory
	{
		public CharacterLevelFactory() { }
		public CharacterLevelFactory(CharacterLevelFactoryConfiguration configuration)
		{
			Initialize(configuration);
		}
		public CharacterLevelFactory(string configPath)
		{
			CharacterLevelFactoryConfiguration config = null;

			if (File.Exists(configPath))
			{
				using (FileStream fs = new FileStream(configPath, FileMode.Open))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(CharacterLevelFactoryConfiguration));
					config = serializer.Deserialize(fs) as CharacterLevelFactoryConfiguration;
				}
			}

			if (config != null)
			{
				Initialize(config);
			}
		}

		protected virtual void Initialize(CharacterLevelFactoryConfiguration configuration)
		{
			m_Configuration = configuration;

			ClassName = configuration.ClassName;
			HitDie = configuration.HitDie;
			SkillPointsPerLevel = configuration.SkillPointsPerLevel;
			FortitudeSave = configuration.FortitudeSave;
			ReflexSave = configuration.ReflexSave;
			WillSave = configuration.WillSave;
			AttackBonus = configuration.AttackBonus;
			DefenseBonus = configuration.DefenseBonus;
			ReputationBonus = configuration.ReputationBonus;
		}

		CharacterLevelFactoryConfiguration m_Configuration = null;

		public CharacterLevel AddLevelTo( Character character )
		{
			CharacterLevel level = DoCreateLevel(character);
			character.Levels.Add(level);
			return level;
		}

		protected virtual BaseCharacterLevel DoCreateLevel( Character character )
		{
			BaseCharacterLevel level = new BaseCharacterLevel(character, ClassName);
			DoAddAttributes(level);
			return level;
		}

		protected virtual void DoAddAttributes( BaseCharacterLevel level )
		{
			DoAddAttackBonus(level);
			DoAddSavingThrow(level);
			DoAddDefenseBonus(level);
			DoAddReputationBonus(level);
			DoAddAbilityScore(level);
			DoAddHitPoints(level);
			DoAddSkillPoints(level);
			DoAddFeats(level);
			DoAddBonusFeats(level);
			DoAddTalents(level);
			DoAddActionPoints(level);
			DoAddWealthBonus(level);
		}

		protected virtual void DoAddAttackBonus(BaseCharacterLevel level)
		{
			AttackBonus.BuildAttributeFor<CharacterAttribute>(
				level, new CharacterAttribute(level.Character, Strings.BASE_ATTACK_BONUS, 0));
		}
		protected virtual void DoAddSavingThrow(BaseCharacterLevel level)
		{
			FortitudeSave.BuildAttributeFor<DependentCharacterAttribute>(
				level, new DependentCharacterAttribute(level.Character, Strings.FORTITUDE_SAVE, 0, Strings.CON_MOD));

			ReflexSave.BuildAttributeFor<DependentCharacterAttribute>(
				level, new DependentCharacterAttribute(level.Character, Strings.REFLEX_SAVE, 0, Strings.DEX_MOD));

			WillSave.BuildAttributeFor<DependentCharacterAttribute>(
				level, new DependentCharacterAttribute(level.Character, Strings.WILL_SAVE, 0, Strings.WIS_MOD));
		}
		protected virtual void DoAddDefenseBonus(BaseCharacterLevel level)
		{
			DefenseBonus.BuildAttributeFor<DefenseBonus>(
				level, new DefenseBonus(level.Character));
		}
		protected virtual void DoAddReputationBonus(BaseCharacterLevel level)
		{
			ReputationBonus.BuildAttributeFor<CharacterAttribute>(
				level, new CharacterAttribute(level.Character, Strings.REPUTATION, 0));
		}
		protected virtual void DoAddAbilityScore( BaseCharacterLevel level ) 
		{
			if( IsOnCharacterLevel(level, 4) )
			{
				level.AbilityScoreBonus = 1;
			}
		}
		protected virtual void DoAddHitPoints( BaseCharacterLevel level )
		{
			level.AddAttribute(new DependentCharacterAttribute(level.Character,
					Strings.HP, RollHelper.Roll(HitDie), Strings.CON_MOD));
		}
		protected virtual void DoAddSkillPoints(BaseCharacterLevel level)
		{
			level.SkillPoints = SkillPointsPerLevel + level.Character.GetEffectedScoreFor(Strings.INT_MOD);
		}
		protected virtual void DoAddFeats( BaseCharacterLevel level ) 
		{
			if( IsOnCharacterLevel(level, 3))
			{
				level.Feats = 1;
			}
		}
		protected virtual void DoAddBonusFeats( BaseCharacterLevel level )
		{
			if( IsOnClassLevel(level, 2, 0) )
			{
				level.Talents = 1;
			}
		}
		protected virtual void DoAddTalents( BaseCharacterLevel level )
		{
			if( IsOnClassLevel(level, 2, 1) )
			{
				level.Talents = 1;
			}
		}
		protected virtual void DoAddActionPoints( BaseCharacterLevel level ) 
		{
			// Action Points = 5 + 1/2 Character Level, rounded down.
			level.AddAttribute(
				new CharacterAttribute(level.Character, "Action Points", 
				5 + System.Math.Floor((double)level.Character.CharacterLevel / 2)));
		}
		protected virtual void DoAddWealthBonus( BaseCharacterLevel level ) 
		{
			double currentWealthBonus = level.Character.GetEffectedScoreFor("Wealth Bonus");
			double currentProfessionSkill = level.Character.GetEffectedScoreFor("Profession");
			double totalBonus = 0;
			double professionCheckResult = GameHelper.Check(currentWealthBonus, currentProfessionSkill);
			if( professionCheckResult >= 0 )
			{
				totalBonus += System.Math.Ceiling(professionCheckResult / 5);
				totalBonus += System.Math.Ceiling(currentProfessionSkill / 5);
			}

			level.AddAttribute(new CharacterAttribute(level.Character, "Wealth Bonus", totalBonus));
		}

		// Derived classes override these properties to provide different progressions
		public string ClassName
		{
			get { return m_ClassName; }
			set { m_ClassName = value; }
		}
		string m_ClassName = "Base";
		 
		public string HitDie
		{
			get { return m_HitDie; }
			set { m_HitDie = value; }
		}
		string m_HitDie = "Dice.Roll(1, 6)";

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

		protected static bool IsOnLevel( int level, int every, int offset )
		{
			return ( System.Math.IEEERemainder(level + offset, every) == 0 );
		}
		protected static bool IsOnClassLevel( BaseCharacterLevel level, int every )
		{
			return IsOnClassLevel(level, every, 0);
		}
		protected static bool IsOnClassLevel( BaseCharacterLevel level, int every, int offset )
		{
			int levels = level.Character.GetLevelsFor(level.ClassName) + offset;
			return IsOnLevel(levels, every, offset);
		}
		protected static bool IsOnCharacterLevel( BaseCharacterLevel level, int every )
		{
			return IsOnCharacterLevel(level, every, 0);
		}
		protected static bool IsOnCharacterLevel( BaseCharacterLevel level, int every, int offset )
		{
			int levels = level.Character.CharacterLevel;
			return IsOnLevel(levels, every, offset);
		}
	}
}