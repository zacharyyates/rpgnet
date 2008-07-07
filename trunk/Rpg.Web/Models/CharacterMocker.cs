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
			CharacterLevel lvl1 = new CharacterLevel(dto.Character);
			lvl1.IsActive = true;
			
			lvl1.AddAttribute(new CharacterAttribute(dto.Character, "Str", 15));
			lvl1.AddAttribute(new AbilityModifier(dto.Character, "Str"));
			lvl1.AddAttribute(new AbilityModifierPlusHalfLevel(dto.Character, "Str"));

			lvl1.AddAttribute(new CharacterAttribute(dto.Character, "Con", 14));
			lvl1.AddAttribute(new AbilityModifier(dto.Character, "Con"));
			lvl1.AddAttribute(new AbilityModifierPlusHalfLevel(dto.Character, "Con"));

			lvl1.AddAttribute(new CharacterAttribute(dto.Character, "Dex", 20));
			lvl1.AddAttribute(new AbilityModifier(dto.Character, "Dex"));
			lvl1.AddAttribute(new AbilityModifierPlusHalfLevel(dto.Character, "Dex"));

			dto.Character.Levels.Add(lvl1);
			
			for (int i = 0; i < 8; i++) // i = extra levels
			{
				dto.Character.Levels.Add(new CharacterLevel(dto.Character));
			}

			return dto;
		}
	}
}