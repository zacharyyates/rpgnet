/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 6/24/2008
 */
namespace YatesMorrison.RolePlay
{
	using System;

	[Serializable]
	public class Item : Actor
	{
		public virtual MonetaryValue Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		protected MonetaryValue m_Value;

		public override string ToString()
		{
			return Name + " (" + Value.ToString() + ")";
		}
	}
}