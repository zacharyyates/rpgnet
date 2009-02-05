/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2/3/2009
 */
namespace YatesMorrison.RolePlay
{
	using System.Collections.Generic;

	public abstract class Weapon : Equipment
	{
		public virtual double MaxDamage { get; set; }

		public abstract void Attack();
	}
}