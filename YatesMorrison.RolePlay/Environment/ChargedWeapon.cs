/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.13.2009
 */
namespace YatesMorrison.RolePlay
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public abstract class ChargedWeapon : Weapon
	{
		public ReadOnlyCollection<Charge> Charges
		{
			get { return new ReadOnlyCollection<Charge>(m_Charges.ToList()); }
		}
		Stack<Charge> m_Charges = new Stack<Charge>();

		/// <summary>
		/// Expends a single charge from the weapon
		/// </summary>
		protected virtual Charge Expend()
		{
			if (Charges.Count > 0)
			{
				var charge = m_Charges.Peek();
				if (charge.Quantity > 0)
				{
					charge.Quantity -= 1;

					if (charge.Quantity <= 0) // that particular charge is expended, pop it
					{
						m_Charges.Pop();
					}

					return charge;
				}
				else
				{
					m_Charges.Pop(); // no charges left, pop the charge
				}
			}

			return null; // no charges left
		}

		public int MaxCharges { get; set; }
		public int CurrentCharges
		{
			get { return Charges.Sum(c => c.Quantity); }
		}

		public Charge Load(Charge charge)
		{
			int spaceLeft = MaxCharges - CurrentCharges;
			if (spaceLeft > 0)
			{
				var loadedCharge = charge.Copy();
				loadedCharge.Quantity = spaceLeft;
				charge.Quantity -= spaceLeft;
				m_Charges.Push(loadedCharge);
			}
			return charge;
		}

		protected override IDamage GetDamage()
		{
			var charge = Expend();
			if (charge != null)
			{
				return charge.Expend();
			}
			else
			{
				return null;
			}
		}
	}
}