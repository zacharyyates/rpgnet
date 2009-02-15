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
		/// <summary>
		/// When implemented in a derived class, gets an <see cref="IDamage" /> object representing the possible damage
		/// </summary>
		public abstract IDamage Damage { get; }

		/// <summary>
		/// Identifies the type of the <see cref="Charge"/>. <see cref="Charge"/>s with the same <see cref="Charge.Type" /> are compatible, regardless of <see cref="Charge.SubType"/>
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Identifies the subtype of the <see cref="Charge"/>
		/// </summary>
		public string SubType { get; set; }
	}
}