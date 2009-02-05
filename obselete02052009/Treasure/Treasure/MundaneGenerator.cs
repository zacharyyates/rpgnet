/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneGenerator : BaseItemGenerator
	{
		public MundaneGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate goods
			int roll = (int)Dice.Roll(100);
			var query = from m in m_DataContext.Mundane_Items
							   where m.Low <= roll &&
							   m.High >= roll
							   select m;
			var row = query.Single<Mundane_Item>();

			switch( (MundaneItemType)row.MundaneItemType )
			{
				case MundaneItemType.AlchemicalItem:
					new MundaneAlchemicalGenerator(m_DataContext).Generate(items); break;
				case MundaneItemType.Armor:
					new MundaneArmorGenerator(m_DataContext).Generate(items); break;
				case MundaneItemType.Weapons:
					new MundaneWeaponGenerator(m_DataContext).Generate(items); break;
				case MundaneItemType.ToolGear:
					new MundaneToolGearGenerator(m_DataContext).Generate(items); break;

				default: break;
			}
		}
	}
}