/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy
{
	public class TargetedAttack : Attack
	{
		public TargetedAttack() : base("Targeted Attack", "TGTATTK", "") { }
		public string BodyArea { get; set; }
		protected override Armor Armor
		{
			get { return Target.GetEquipmentBySlot(BodyArea) as Armor; }
		}
	}
}