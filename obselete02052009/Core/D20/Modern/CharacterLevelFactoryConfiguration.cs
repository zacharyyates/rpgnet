/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/20/2007
 */

namespace YatesMorrison.RolePlay.D20.Modern
{
	public class CharacterLevelFactoryConfiguration
	{
		public string ClassName { get; set; }
		public DieType HitDie { get; set; }
		public double SkillPointsPerLevel { get; set; }
		public Progression FortitudeSave { get; set; }
		public Progression ReflexSave { get; set; }
		public Progression WillSave { get; set; }
		public Progression AttackBonus { get; set; }
		public Progression DefenseBonus { get; set; }
		public Progression ReputationBonus { get; set; }
	}
}