/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public class Ability : CharacterAttribute
	{
		public Ability( Character character ) : base(character) { }
		public Ability( Character character, string name, double score ) : base(character, name, score) { }
	}
}