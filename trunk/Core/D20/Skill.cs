/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System;

namespace YatesMorrison.RolePlay.D20
{
	public class Skill : DependentCharacterAttribute
	{
		public Skill(Character character) : base(character) { }
		public Skill(Character character, string name, double simpleScore, string keyAbility) : base(character, name, simpleScore, keyAbility + " Modifier") { }
		public Skill(Character character, string name, double simpleScore, string keyAbility, bool isClassSkill, bool hasArmorPenalty) : this(character, name, simpleScore, keyAbility) 
		{
			IsClassSkill = isClassSkill;
			HasArmorPenalty = hasArmorPenalty;
		}

		public bool IsClassSkill
		{
			get { return m_IsClassSkill; }
			set { m_IsClassSkill = value; }
		}
		bool m_IsClassSkill = false;

		public bool HasArmorPenalty
		{
			get { return m_HasArmorPenalty; }
			set { m_HasArmorPenalty = value; }
		}
		bool m_HasArmorPenalty = false;

		public double MaxRanks
		{
			get
			{
				if (IsClassSkill)
				{
					return m_Character.Levels.Count + 3;
				}
				else
				{
					return System.Math.Floor((double)((m_Character.Levels.Count + 3) / 2));
				}
			}
		}

		public override double SimpleScore
		{
			get { return base.SimpleScore; }
			set
			{
				if (value > MaxRanks)
				{
					throw new InvalidOperationException("Value exceeds MaxRanks for this skill.");
				}
				base.SimpleScore = value;
			}
		}

		public override double GetCalculatedScore(double simpleScore)
		{
			return KeyAttributeValue + simpleScore + (HasArmorPenalty ? m_Character.GetEffectedScoreFor("Armor Penalty") : 0);
		}
	}
}