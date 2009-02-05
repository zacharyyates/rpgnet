/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 1.30.2009
 */
namespace YatesMorrison.Entropy
{
	using YatesMorrison.RolePlay;

	public static class CharacterFactory
	{
		public static Character Create()
		{
			Character character = new Character();

			// Attach the basic attributes
			character.Add(new Attribute("Strength", "ST", "", 5));
			character.Add(new Attribute("Perception", "PE", "", 5));
			character.Add(new Attribute("Endurance", "EN", "", 5));
			character.Add(new Attribute("Charisma", "CH", "", 5));
			character.Add(new Attribute("Intelligence", "IN", "", 5));
			character.Add(new Attribute("Agility", "AG", "", 5));
			character.Add(new Attribute("Luck", "LK", "", 5));

			// Attach derived attributes
			character.Add(new MaxHitPoints());
			character.Add(new ArmorClass());
			character.Add(new ActionPoints());
			character.Add(new CarryWeight());
			character.Add(new DamageResistance());
			character.Add(new BiologicalResistance());
			character.Add(new RadiationResistance());
			character.Add(new Sequence());
			character.Add(new HealingRate());
			character.Add(new CriticalChance());
			character.Add(new MeleeDamage());

			// Attach knowledge areas
			character.Add(new Attribute("Learn", "", "", 0));
			character.Add(new Attribute("Marksman", "", "", 0));
			character.Add(new Attribute("Melee", "", "", 0));
			character.Add(new Attribute("Survival", "", "", 0));
			character.Add(new Attribute("Subterfuge", "", "", 0));
			character.Add(new Attribute("Science", "", "", 0));

			// Attach skills
			character.Add(new SmallGuns());
			character.Add(new BigGuns());
			character.Add(new EnergyWeapons());
			character.Add(new Primitive());
			character.Add(new Slash());
			character.Add(new Pierce());
			character.Add(new Bludgeon());
			character.Add(new Throw());
			character.Add(new Strike());
			character.Add(new Wrestle());
			character.Add(new Track());
			character.Add(new Forage());
			character.Add(new Hunt());
			character.Add(new Medic());
			character.Add(new Camp());
			character.Add(new HandleAnimal());
			character.Add(new Sneak());
			character.Add(new Lockpick());
			character.Add(new Steal());
			character.Add(new Gambling());
			character.Add(new Traps());
			character.Add(new Disguise());
			character.Add(new Repair());
			character.Add(new Pilot());
			character.Add(new Technology());
			character.Add(new Chemistry());
			character.Add(new Physics());

			// Attach aspects
			character.Add(new Aspect("Current Hit Points", "CHP", "", 30));
			

			//// test: Attach equipment
			//Equipment equipment = new Equipment()
			//{
			//    Name = "Gun",
			//    Description = "Pew Pew",
			//    Value = new MonetaryValue(5),
			//    Weight = 10
			//};
			//equipment.Attach(new Modifier() { AttributeName = "Strength", Operator = Operator.Attach, Value = 5 });
			//character.Equip(equipment);

			return character;
		}
	}
}