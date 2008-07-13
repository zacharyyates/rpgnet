/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/6/2008
 */

namespace YatesMorrison.Rpg.Dnd4
{
	public class Ability : CharacterAttribute
	{
		public Ability(Character character) : base(character) { }
		public Ability(Character character, string name, double score) : base(character, name, score) { }
	}
}