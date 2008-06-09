/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneUncommonWeaponGenerator : BaseItemGenerator
	{
		public MundaneUncommonWeaponGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Magic_UncommonWeapons
						where a.Low <= roll &&
						a.High >= roll
						select a;
			var row = query.Single<Magic_UncommonWeapon>();

			Item item = new Item();

			item.Name = row.Description;
			item.Value = new CoinMonetaryValue(CoinType.Gold, row.WeaponCost);

			items.Add(item);
		}
	}
}