using YatesMorrison.Rpg;
using YatesMorrison.Rpg.Dnd4;

namespace Rpg.Web.Models
{
	public static class CharacterMocker
	{
		public static CharacterDto Create()
		{
			CharacterDto dto = new CharacterDto
			{
				Character = new Dnd4Character
				{
					GivenName = "Hammurabi",
					Surname = "Half-elven",
					CharacterClass = "Ranger"
				}
			};

			dto.Character.SizeCategory = SizeCategory.Medium;

			var lvl1 = new Dnd4CharacterLevel(dto.Character);
			dto.Character.Levels.Add(lvl1);
			lvl1.IsActive = true;

			foreach (string abbrv in dto.Character.AbilityScoreNames.Keys)
			{
				lvl1.AddAbility(new Ability(dto.Character, abbrv, Dice.Roll(4, DieType.D6, DieRollOptions.DropLowestOne)));
			}

			// HP, Defenses
			lvl1.AddAttribute(new HitPoints(dto.Character, 20 + dto.Character.GetSimpleScoreFor("Con")));
			lvl1.AddAttribute(new BloodiedValue(dto.Character));
			lvl1.AddAttribute(new SurgeValue(dto.Character));

			lvl1.AddAttribute(new ArmorClassDefense(dto.Character));
			lvl1.AddAttribute(new FortitudeDefense(dto.Character));
			lvl1.AddAttribute(new ReflexDefense(dto.Character));
			lvl1.AddAttribute(new WillDefense(dto.Character));
			lvl1.AddAttribute(new CharacterAttribute(dto.Character, "HS", 5));
			
			for (int i = 0; i < 8; i++) // i = extra levels
			{
				var level = new Dnd4CharacterLevel(dto.Character);
				dto.Character.Levels.Add(level);
				level.IsActive = true;
				level.AddAttribute(new HitPoints(dto.Character, 5));
			}

			return dto;
		}
	}
}