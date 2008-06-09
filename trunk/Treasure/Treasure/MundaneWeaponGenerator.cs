/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 1/24/2008
 */

using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace YatesMorrison.RolePlay.D20.Past.Treasure
{
	public class MundaneWeaponGenerator : BaseItemGenerator
	{
		public MundaneWeaponGenerator( TreasureDataContext dataContext ) : base(dataContext) { }

		public override void Generate( Collection<Item> items )
		{
			// Calculate item
			int roll = (int)Dice.Roll(100);
			var query = from a in m_DataContext.Mundane_ItemWeaponTypes
						where a.Low <= roll &&
						a.High >= roll
						select a;
			var row = query.Single<Mundane_ItemWeaponType>();

			// Forward to the Masterwork weapon tables
			switch( (MundaneWeaponType)row.WeaponType )
			{
				case MundaneWeaponType.CommonMelee:
					new MundaneCommonMeleeWeaponGenerator(m_DataContext).Generate(items); break;
				case MundaneWeaponType.CommonRanged:
					new MundaneCommonRangedWeaponGenerator(m_DataContext).Generate(items); break;
				case MundaneWeaponType.Uncommon:
					new MundaneUncommonWeaponGenerator(m_DataContext).Generate(items); break;

				default: throw new IndexOutOfRangeException("Roll: " + roll + " not found in MundaneWeapon table.");
			}
		}
	}

	public enum MundaneWeaponType
	{
		CommonMelee = 1,
		Uncommon = 2,
		CommonRanged = 3
	}
}