/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class GemsGenerator : BaseItemGenerator
	{
		public GemsGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate gems
			int gemsPercentile = (int)Dice.Roll(100);
			var gemsQuery = from g in m_DataContext.Goods_Gems
							where g.Low <= gemsPercentile &&
							g.High >= gemsPercentile
							select g;
			var gemsRow = gemsQuery.Single<Goods_Gem>();

			Item gems = new Item();

			// Random gem name
			int gemTextCount = gemsRow.Goods_GemTexts.Count();
			int gemTextToUse = (int)Dice.Roll(gemTextCount) - 1;
			string gemText = gemsRow.Goods_GemTexts.ElementAt(gemTextToUse).Text;

			gems.Name = gemText;
			int gemValue = (int)( Dice.Roll(gemsRow.DiceNumber, gemsRow.DiceRange) * gemsRow.Multiplier );
			gems.Value = new CoinMonetaryValue(CoinType.Gold, gemValue);

			items.Add(gems);
		}
	}
}