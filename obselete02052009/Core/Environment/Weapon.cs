using System;
using System.Collections.Generic;
using System.Text;

namespace YatesMorrison.RolePlay
{
	public class Weapon : Item
	{
		public Range Range
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}

		public IList<Ammunition> Ammunition
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}
	}
}
