/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.13.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public abstract class ChargedWeapon : Weapon
	{
		public Magizene Magizene
		{
			get { return m_Magizene; }
			set
			{
				if (AcceptsMagizeneType.Equals(value.Type, StringComparison.InvariantCultureIgnoreCase))
				{
					m_Magizene = value;
				}
			}
		}
		Magizene m_Magizene;

		public string AcceptsMagizeneType { get; set; }

		/// <summary>
		/// Expends a <see cref="Charge"/> and gets the <see cref="IDamage"/> from it
		/// </summary>
		/// <returns><see cref="IDamage"/></returns>
		protected override IDamage GetDamage()
		{
			var charge = Magizene.Expend();
			if (charge != null)
			{
				return charge.Damage;
			}
			else
			{
				return null;
			}
		}
	}
}