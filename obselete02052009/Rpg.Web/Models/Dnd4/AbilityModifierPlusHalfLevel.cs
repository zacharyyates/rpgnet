/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 7/6/2008
 */

using YatesMorrison.Rpg;
using System;
namespace YatesMorrison.Rpg.Dnd4
{
	public class AbilityModifierPlusHalfLevel : DependentCharacterAttribute
	{
		public AbilityModifierPlusHalfLevel(Character character) : base(character) { }
		public AbilityModifierPlusHalfLevel(Character character, string keyAbility) : base(character, keyAbility + "Mod+1/2Lvl", 0, keyAbility + "Mod") { }

		public override double SimpleScore
		{
			get { return KeyAttributeValue + Math.Floor((double)m_Character.CharacterLevel / 2); }
			set { }
		}
	}
}