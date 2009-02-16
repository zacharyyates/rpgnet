/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.RolePlay
{
	public abstract class Weapon : Equipment<IDamage>
	{
		/// <summary>
		/// Uses the <see cref="Weapon"/> and returns <see cref="IDamage"/> representing the possible weapon damage
		/// </summary>
		/// <returns></returns>
		public override IDamage Use()
		{
			base.Use();
			return GetDamage();
		}

		/// <summary>
		/// When implemented in a derived class, returns an ,<see cref="IDamage"/> object representing possible damage
		/// </summary>
		protected abstract IDamage GetDamage();
	}
}