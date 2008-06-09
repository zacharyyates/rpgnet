/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/10/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public static class GameHelper
	{
		public static double Check( double difficultyClass, double totalModifier )
		{
			return RollHelper.Roll("1d20+" + totalModifier) - difficultyClass;
		}
		public static double Check( double difficultyClass, Character character, string attribute )
		{
			return Check(difficultyClass, character.GetEffectedScoreFor(attribute));
		}

		public static bool CheckSuccess( double difficultyClass, double totalModifier )
		{
			return Check(difficultyClass, totalModifier) >= 0;
		}
	}
}