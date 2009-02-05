/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/5/2007
 */

using System;

namespace YatesMorrison.Rpg.Dnd4
{
	public class AbilityModifier : DependentCharacterAttribute
	{
		public AbilityModifier( Character character ) : base(character) { }
		public AbilityModifier( Character character, string keyAbility ) : base(character, keyAbility + "Mod", 0, keyAbility) { }

		public override double GetCalculatedScore( double simpleScore )
		{
			return simpleScore;
		}

		public override double SimpleScore
		{
			get { return Math.Floor(( KeyAttributeValue - 10 ) / 2); }
			set { }
		}
	}
}