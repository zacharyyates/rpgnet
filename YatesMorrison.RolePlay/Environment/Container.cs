/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.15.2009
 */
namespace YatesMorrison.RolePlay
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Container<T>
		where T : Item
	{
		// todo: Add a TryAdd(), TryRemove impl?
		/// <summary>
		/// Adds an item to the <see cref="Container"/>
		/// </summary>
		/// <param name="item">The <see cref="Item" /></param>
		/// <returns>True on success, False on failure</returns>
		public virtual bool Add(T item)
		{
			m_Items.Add(item);
			return true;
		}
		/// <summary>
		/// Removes an item from the <see cref="Container"/>
		/// </summary>
		/// <param name="item">The <see cref="Item" /></param>
		/// <returns>True on success, False on failure</returns>
		public virtual bool Remove(T item)
		{
			m_Items.Remove(item);
			return true;
		}

		public virtual ReadOnlyCollection<T> Items
		{
			get { return new ReadOnlyCollection<T>(m_Items); }
		}
		List<T> m_Items = new List<T>();
	}
}