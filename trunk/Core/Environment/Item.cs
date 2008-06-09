using System;
using System.Collections.Generic;
using System.Text;

namespace YatesMorrison.RolePlay
{
	public class Item : Actor
	{
		public virtual MonetaryValue Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		protected MonetaryValue m_Value;

		public override string GetDebugString()
		{
			return Name + " (" + Value.GetDebugString() + ")";
		}
	}
}
