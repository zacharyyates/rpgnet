/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/13/2008
 */

namespace YatesMorrison.Rpg.Dnd4
{
	public class Dnd4CharacterLevel : CharacterLevel
	{
		public Dnd4CharacterLevel(Character character) : base(character) { }

		public void AddAbility(Ability ability)
		{
			AddAttribute(ability);
			AddAttribute(new AbilityModifier(Character, ability.Name));
			AddAttribute(new AbilityModifierPlusHalfLevel(Character, ability.Name));
		}
	}
}