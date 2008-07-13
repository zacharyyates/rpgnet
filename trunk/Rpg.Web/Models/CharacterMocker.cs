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
			Dnd4CharacterLevel lvl1 = new Dnd4CharacterLevel(dto.Character);
			lvl1.IsActive = true;

			foreach (string abbrv in dto.Character.AbilityScoreNames.Keys)
			{
				lvl1.AddAbility(new Ability(dto.Character, abbrv, Dice.Roll(4, DieType.D6, DieRollOptions.DropLowestOne)));
			}

			dto.Character.Levels.Add(lvl1);
			
			for (int i = 0; i < 8; i++) // i = extra levels
			{
				dto.Character.Levels.Add(new CharacterLevel(dto.Character));
			}

			return dto;
		}
	}
}