/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;
	using YatesMorrison.Entropy.Web.Views.Combat;
	using YatesMorrison.RolePlay;
	using Entropy = YatesMorrison.Entropy;

	public class CombatController : Controller
	{
		public ActionResult Test()
		{
			var game = new YatesMorrison.Entropy.Game();

			// Create some characters
			var zach = CharacterFactory.Create();
			zach.Add(new Advance() { AttributeName = "Small Guns", Value = 150, IsActive = true }); // beef up my shootery
			var karl = CharacterFactory.Create();

			game.Add(zach);
			game.Add(karl);

			zach.Name = "Zach";
			zach.Location = new Point(1, 1, 0);
			
			karl.Name = "Karl";
			karl.Location = new Point(20, 20, 0);

			// Create a gun for zach
			ChargedWeapon gun = new ChargedWeapon()
			{
				Name = "Pewpewer",
				Range = new Range(100, 20),
				AspectName = "Small Guns",
				AcceptsMagizeneType = "5.7mm Standard"
			};
			zach.Add(gun);
			// Add abilities to zach's gun
			gun.Abilities.Add(new Attack() { Weapon = gun });
			// Add a magizene to the gun
			gun.Magizene = new Magizene()
			{
				Type = "5.7mm Standard",
				AcceptsChargeType = "5.7mm",
				MaxCharges = 20
			};
			gun.Magizene.Load(new Ammunition()
			{
				DamageType = DamageType.Kinetic,
				Quantity = 20,
				Type = "5.7mm",
				SubType = "FMJ",
				MaxDamage = 30,
				MinDamage = 10
			});

			// Create armor for karl
			var armor = new Entropy.Armor()
			{
				Soak = 5,
				Threshold = 0,
				LegalAreas = { "Torso" }
			};
			armor.Add(new Aspect("Current Hit Points", "CHP", "", 10));
			karl.Add(armor);
			karl.Equip(armor, "Torso");

			var shoot = gun.Abilities.Single(a => a.Name.Equals("Attack")) as Attack;
			shoot.Area = "Torso";
			shoot.Target = karl;
			zach.Use(shoot);

			return View(new CombatResult() // todo: add a combat log sink
				{
					Initiator = zach,
					Target = karl
				});
		}
	}
}