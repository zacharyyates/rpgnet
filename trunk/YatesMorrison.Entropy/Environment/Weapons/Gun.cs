/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy.Environment.Weapons
{
	using System;
	using YatesMorrison.RolePlay;

	[Serializable]
	public class Gun : ChargedWeapon
	{
		public Gun()
		{
			Abilities.Add(new Attack()
			{
				Weapon = this,
				Description = "SHOOT SHIT@!"
			});
			Abilities.Add(new TargetedAttack()
			{
				Weapon = this,
				BodyArea = "Torso",
				Description = "Aim for the EYES!"
			});
		}
	}
}