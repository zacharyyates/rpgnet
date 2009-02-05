/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneDarkwoodArmorGenerator : BaseItemGenerator
	{
		public MundaneDarkwoodArmorGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Mundane_ItemArmorDarkwoods
						where a.Low <= roll &&
						a.High >= roll
						select a;
			var row = query.Single<Mundane_ItemArmorDarkwood>();

			Item item = new Item();

			double sizeRoll = Dice.Roll(100);
			item.SizeCategory = ( sizeRoll < 11 ? SizeCategory.Small : SizeCategory.Medium );

			item.Name = row.Description;
			item.Value = new CoinMonetaryValue(CoinType.Gold, row.MarketPrice);

			items.Add(item);
		}
	}
}