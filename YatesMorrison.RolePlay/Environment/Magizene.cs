/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public class Magizene : Item
	{
		/// <summary>
		/// The <see cref="Charge"/>s currently loaded in the weapon
		/// </summary>
		public ReadOnlyCollection<Charge> Charges
		{
			get { return new ReadOnlyCollection<Charge>(m_Charges.ToList()); }
		}
		Stack<Charge> m_Charges = new Stack<Charge>();

		/// <summary>
		/// The maximum number of <see cref="Charge"/>s the <see cref="Magizene"/> can hold
		/// </summary>
		public int MaxCharges { get; set; }

		/// <summary>
		/// The current number of <see cref="Charge"/>s the <see cref="Magizene"/> holds
		/// </summary>
		public int CurrentCharges
		{
			get { return Charges.Sum(c => c.Quantity); }
		}

		/// <summary>
		/// The <see cref="Charge.Type"/> that the <see cref="Magizene"/> accepts
		/// </summary>
		public string AcceptsChargeType { get; set; }

		/// <summary>
		/// The type of the <see cref="Magizene"/>
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Loads the weapon with <see cref="Charge"/>s
		/// </summary>
		/// <param name="charge">The <see cref="Charge"/> to load</param>
		/// <returns>A <see cref="Charge"/> object representing the excess charges</returns>
		public Charge Load(Charge charge)
		{
			if (AcceptsChargeType.Equals(charge.Type, StringComparison.InvariantCultureIgnoreCase))
			{
				int spaceLeft = MaxCharges - CurrentCharges;
				if (spaceLeft > 0)
				{
					var splitStack = charge.Split<Charge>(spaceLeft);
					m_Charges.Push(splitStack.First);
					return splitStack.Second;
				}
			}
			return charge;
		}

		/// <summary>
		/// Expends a single charge from the weapon
		/// </summary>
		public virtual Charge Expend()
		{
			if (Charges.Count > 0)
			{
				var charge = m_Charges.Peek();
				if (!charge.IsEmpty)
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

		/// <summary>
		/// Removes all of the <see cref="Charge"/>s from the <see cref="Magizene"/>
		/// </summary>
		/// <returns>The unloaded <see cref="Charge"/>s</returns>
		public IList<Charge> Unload()
		{
			IList<Charge> unloaded = Charges;
			m_Charges.Clear();
			return unloaded;
		}
	}
}