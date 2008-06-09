/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/7/2007
 */

namespace YatesMorrison.RolePlay.D20
{
	public class HitPoints : DependentCharacterAttribute
	{
		public HitPoints( Character character ) : base(character) { }

		public override double SimpleScore
		{
			get { return base.SimpleScore + KeyAttributeValue; }
			set	{ base.SimpleScore = value; }
		}
	}
}