/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy.Web.Controllers
{
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
			Gun gun = new Gun();
			gun.Name = "Pewpewer";
			gun.Range = new Range(100, 20);
			gun.AspectName = "Small Guns";
			zach.Add(gun);

			// Create armor for karl
			var armor = new Entropy.Armor()
			{
				Soak = 5,
				Threshold = 0,
				LegalSlots = { "Torso" }
			};
			armor.Add(new Aspect("Current Hit Points", "CHP", "", 10));
			karl.Add(armor);
			karl.Equip(armor, "Torso");

			var shoot = gun.Abilities.Single(a => a.Name.Equals("Targeted Attack")) as TargetedAttack;
			shoot.BodyArea = "Head";
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