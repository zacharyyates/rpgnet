/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 1.6.2009
 */
namespace YatesMorrison.Entropy
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Character : YatesMorrison.RolePlay.Character
	{
		public Character()
		{
			m_Equipment.Add("Torso", null);
			m_Equipment.Add("Head", null);
			m_Equipment.Add("Hands", null);
			m_Equipment.Add("Feet", null);
		}

		public int ExperiencePoints { get; set; }
		public int SpentExperiencePoints { get; set; }

		public override void Add(Aspect child)
		{
			base.Add(child);
			// sort the attributes according to type
			if (PrimaryAttributeNames.Contains(child.Name)) { m_Primary.Add(child as YatesMorrison.RolePlay.Attribute); }
			if (DerivedAttributeNames.Contains(child.Name)) { m_Derived.Add(child as DerivedAttribute); }
			if (KnowledgeAreaNames.Contains(child.Name)) { m_KnowledgeAreas.Add(child as YatesMorrison.RolePlay.Attribute); }
		}

		public ReadOnlyCollection<YatesMorrison.RolePlay.Attribute> Primary
		{
			get { return new ReadOnlyCollection<YatesMorrison.RolePlay.Attribute>(m_Primary); }
		}
		List<YatesMorrison.RolePlay.Attribute> m_Primary = new List<YatesMorrison.RolePlay.Attribute>();

		public ReadOnlyCollection<DerivedAttribute> Derived
		{
			get { return new ReadOnlyCollection<DerivedAttribute>(m_Derived); }
		}
		List<DerivedAttribute> m_Derived = new List<DerivedAttribute>();

		public ReadOnlyCollection<YatesMorrison.RolePlay.Attribute> KnowledgeAreas
		{
			get { return new ReadOnlyCollection<YatesMorrison.RolePlay.Attribute>(m_KnowledgeAreas); }
		}
		List<YatesMorrison.RolePlay.Attribute> m_KnowledgeAreas = new List<YatesMorrison.RolePlay.Attribute>();

		public string[] PrimaryAttributeNames
		{
			get { return new string[] { "Strength", "Perception", "Endurance", "Charisma", "Intelligence", "Agility", "Luck" }; }
		}
		public string[] DerivedAttributeNames
		{
			get { return new string[] { "Max Hit Points", "Armor Class", "Action Points", "Carry Weight", "Damage Resistance", "Biological Resistance", "Radiation Resistance", "Sequence", "Healing Rate", "Critical Chance", "Melee Damage" }; }
		}
		public string[] KnowledgeAreaNames
		{
			get { return new string[] { "Learn", "Marksman", "Melee", "Survival", "Subterfuge", "Science" }; }
		}
	}
}