/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public interface IMagicItemGenerator
	{
		void Generate( ItemsType type, Collection<Item> items );
	}

	public abstract class BaseMagicItemGenerator : IMagicItemGenerator
	{
		public BaseMagicItemGenerator( TreasureDataContext dataContext )
		{
			m_DataContext = dataContext;
		}

		protected TreasureDataContext m_DataContext;

		public abstract void Generate( ItemsType type, Collection<Item> items );
		public void Generate( ItemsType type, Collection<Item> items, int quantity )
		{
			for( int index = 0; index < quantity; index++ )
			{
				Generate(type, items);
			}
		}
	}

	public class MagicItemGenerator : BaseMagicItemGenerator
	{
		public MagicItemGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( ItemsType type, Collection<Item> items )
		{
			IQueryable<Magic_Item> query = null;
			int roll = (int)Dice.Roll(100);

			switch( type )
			{
				case ItemsType.Minor:
					query = from i in m_DataContext.Magic_Items
							where i.MinorLow <= roll &&
							i.MinorHigh >= roll
							select i;
					break;
				case ItemsType.Medium:
					query = from i in m_DataContext.Magic_Items
							where i.MediumLow <= roll &&
							i.MediumHigh >= roll
							select i;
					break;
				case ItemsType.Major:
					query = from i in m_DataContext.Magic_Items
							where i.MajorLow <= roll &&
							i.MajorHigh >= roll
							select i;
					break;

				default:
				case ItemsType.Mundane:
				case ItemsType.Nothing:
					break;
			}

			if( query != null )
			{
				var row = query.Single<Magic_Item>();
				// forward the generation to the specific table indicated
				switch( (MagicItemType)row.MagicItemType )
				{
					default:
					case MagicItemType.ArmorAndShields:
						new MagicArmorShieldGenerator(m_DataContext).Generate((ItemsType)row.MagicItemType, items); break;
					case MagicItemType.Weapons:
						new MagicWeaponGenerator(m_DataContext).Generate((ItemsType)row.MagicItemType, items); break;
				}
			}
		}
	}

	public enum MagicItemType
	{
		ArmorAndShields = 1,
		Weapons = 2,
		Potions = 3,
		Rings = 4,
		Rods = 5,
		Scrolls = 6,
		Staffs = 7,
		Wands = 8,
		WondrousItems = 9
	}
}