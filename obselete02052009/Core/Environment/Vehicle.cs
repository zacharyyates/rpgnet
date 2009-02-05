/* Zachary Yates
 * Copyright 2007 YatesMorrison Software, LLC.
 * 11/4/2007
 */

using System.Collections.Generic;

namespace YatesMorrison.RolePlay
{
	public class Vehicle : Item
	{
		public IList<Seat> Seats
		{
			get { return m_Seats; }
			set { m_Seats = value; }
		}
		IList<Seat> m_Seats = null;
	}
}