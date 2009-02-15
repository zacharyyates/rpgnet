/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.RolePlay
{
	public abstract class Weapon : Equipment<IDamage>
	{
		public override IDamage Use()
		{
			base.Use();
			return GetDamage();
		}

		/// <summary>
		/// When implemented in a derived class, returns an IDamage object representing possible damage
		/// </summary>
		protected abstract IDamage GetDamage();
	}
}