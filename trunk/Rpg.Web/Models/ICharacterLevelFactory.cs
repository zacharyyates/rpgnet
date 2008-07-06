/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

namespace YatesMorrison.Rpg
{
	public interface ICharacterLevelFactory
	{
		CharacterLevel AddLevelTo( Character character );
	}
}