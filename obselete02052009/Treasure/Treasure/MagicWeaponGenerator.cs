/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/26/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MagicWeaponGenerator : BaseMagicItemGenerator
	{
		public MagicWeaponGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( ItemsType type, Collection<Item> items )
		{
			throw new System.NotImplementedException();
		}
	}
}
