/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.13.2009
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public abstract class Charge : StackableItem
	{
		public virtual IDamage Expend()
		{
			if (Quantity > 0)
			{
				Quantity -= 1;
				return Damage;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// When implemented in a derived class, gets an <see cref="IDamage" /> object representing the possible damage
		/// </summary>
		protected abstract IDamage Damage { get; }

		/// <summary>
		/// Used for splitting a stack of charges in two, todo: implement in StackableItem
		/// </summary>
		/// <returns></returns>
		public Charge Copy() { return this.MemberwiseClone() as Charge; }
	}
}