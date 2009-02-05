/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/23/08
 */

namespace YatesMorrison.Rpg
{
	public abstract class Defense : DependentCharacterAttribute
	{
		Defense(Character character) : base(character) { }
		public Defense(Character character, string name, double simpleScore, string keyAttribute) : base(character, name, simpleScore, keyAttribute) { }

		public override double GetCalculatedScore(double simpleScore)
		{
			return 10 + (m_Character.CharacterLevel / 2) + KeyAttributeValue;
		}
	}

	public class ArmorClassDefense : Defense
	{
		public ArmorClassDefense(Character character) : base(character, "AC", 0, "Dex") { }
	}

	public class FortitudeDefense : Defense
	{
		public FortitudeDefense(Character character)
			: base(character, "Fort", 0, "")
		{
			if (character.GetSimpleScoreFor("Str") > character.GetSimpleScoreFor("Con"))
				KeyAttribute = "Str";
			else
				KeyAttribute = "Con";
		}
	}

	public class ReflexDefense : Defense
	{
		public ReflexDefense(Character character)
			: base(character, "Ref", 0, "")
		{
			if (character.GetSimpleScoreFor("Dex") > character.GetSimpleScoreFor("Int"))
				KeyAttribute = "Dex";
			else
				KeyAttribute = "Int";
		}
	}

	public class WillDefense : Defense
	{
		public WillDefense(Character character)
			: base(character, "Will", 0, "")
		{
			if (character.GetSimpleScoreFor("Wis") > character.GetSimpleScoreFor("Cha"))
				KeyAttribute = "Wis";
			else
				KeyAttribute = "Cha";
		}
	}
}