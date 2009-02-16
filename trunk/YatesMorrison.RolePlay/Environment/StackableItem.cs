/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software Company
 * 1.22.2008
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using YatesMorrison.Functional;

	[Serializable]
	public class StackableItem : Item
	{
		/// <summary>
		/// Returns True if the <see cref="StackableItem.Quantity"/> less than or equal to zero
		/// </summary>
		public bool IsEmpty
		{
			get { return Quantity <= 0; }
		}

		/// <summary>
		/// The number of <see cref="Item"/>s in the stack
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// The combined weight of all the <see cref="Item"/>s
		/// </summary>
		public override double Weight
		{
			get { return m_Weight * Quantity; }
			set { m_Weight = value; }
		}

		/// <summary>
		/// Splits a <see cref="StackableItem"/> in two
		/// </summary>
		/// <typeparam name="T">The type to return</typeparam>
		/// <param name="count">The number of items in the first <see cref="StackableItem"/></param>
		/// <returns><see cref="Union"/> of type T</returns>
		public Union<T, T> Split<T>(int count)
			where T : StackableItem
		{
			var stack2 = this.MemberwiseClone() as StackableItem;
			stack2.Quantity = this.Quantity - count;
			this.Quantity = count;
			return new Union<T, T>(this as T, stack2 as T);
		}
		/// <summary>
		/// Splits a <see cref="StackableItem"/> in two
		/// </summary>
		/// <param name="count">The number of items in the first <see cref="StackableItem"/></param>
		/// <returns><see cref="Union"/> of <see cref="StackableItem"/></returns>
		public Union<StackableItem, StackableItem> Split(int count)
		{
			return Split<StackableItem>(count);
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", base.ToString(), Quantity);
		}
	}
}