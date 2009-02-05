/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class ArtObjectsGenerator : BaseItemGenerator
	{
		public ArtObjectsGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate art
			int artPercentile = (int)Dice.Roll(100);
			var artQuery = from g in m_DataContext.Goods_ArtObjects
						   where g.Low <= artPercentile &&
						   g.High >= artPercentile
						   select g;
			var artRow = artQuery.Single<Goods_ArtObject>();

			Item art = new Item();

			// Random art name
			int artTextCount = artRow.Goods_ArtObjectTexts.Count();
			int artTextToUse = (int)Dice.Roll(artTextCount) - 1;
			string artText = artRow.Goods_ArtObjectTexts.ElementAt(artTextToUse).ArtObjectText;

			art.Name = artText;
			int artValue = (int)( Dice.Roll(artRow.DiceNumber, artRow.DiceRange) * artRow.Multiplier );
			art.Value = new CoinMonetaryValue(CoinType.Gold, artValue);

			items.Add(art);
		}
	}
}