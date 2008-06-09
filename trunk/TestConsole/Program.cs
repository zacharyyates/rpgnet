/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/12/2007
 */

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using YatesMorrison.Math.Eval;
using YatesMorrison.RolePlay.D20;
using YatesMorrison.RolePlay.D20.Modern;

namespace YatesMorrison.RolePlay.Test
{
	class Program
	{
		static void Main( string[] args )
		{
			CreateCharacter();

			Console.WriteLine("Press enter to continue...");
			Console.ReadLine();
		}

		static void DieRoll()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("Try #" + (i + 1) + ": 4d6 drop lowest 1 = " + Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1)));
			}
		}

		static void BuildExpression()
		{
			double[] args = new double[] { 5 };

			ExpressionParser ep = new ExpressionParser();
			string expr = "4 + 5 * args[0]";
			Console.WriteLine("Compiling: " + expr);
			if (ep.Initialize(expr))
			{
				Console.WriteLine("Evaluating: " + expr);
				Console.WriteLine("Result: " + ep.Eval(5));
			}
			else
			{
				Console.WriteLine("Errors: " + Environment.NewLine + ep.Errors);
			}
		}

		static void CreateCharacter()
		{
			ICharacterLevelFactory strong = new CharacterLevelFactory("StrongConfig.xml");
			LevelCharacter(strong);
		}

		static void LevelCharacter(ICharacterLevelFactory levelFactory)
		{
			// Build a Strong Character with 1 level then visualize the results
			Character character = new Character();
			
			// Create Level 1
			CharacterLevel level = levelFactory.AddLevelTo(character);
			
			level.AddAttribute(new Ability(character, "Strength", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Strength"));

			level.AddAttribute(new Ability(character, "Dexterity", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Dexterity"));

			level.AddAttribute(new Ability(character, "Constitution", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Constitution"));

			level.AddAttribute(new Ability(character, "Intelligence", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Intelligence"));

			level.AddAttribute(new Ability(character, "Wisdom", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Wisdom"));

			level.AddAttribute(new Ability(character, "Charisma", Dice.Roll(4, 6, new DieRollOptions(DieRollOptionType.DropLowest, 1))));
			level.AddAttribute(new AbilityModifier(character, "Charisma"));

			level.AddAttribute(new CharacterAttribute(character, "Wealth Bonus", Dice.Roll(2, 4)));
			level.AddAttribute(new CharacterAttribute(character, "Reputation Bonus", 0));
			level.AddAttribute(new Skill(character, "Profession", 0, "Wisdom", true, false));

			// Add 5 more
			for (int i = 0; i < 5; i++)
			{
				levelFactory.AddLevelTo(character);
			}

			ICharacterVisualizer visualizer = new TextCharacterVisualizer();
			StringBuilder sb = new StringBuilder();
			visualizer.Visualize(character, sb);

			Console.WriteLine(sb.ToString());
		}

		static void WriteConfig()
		{
			// Serialize a levelfactoryconfig
			CharacterLevelFactoryConfiguration config = new CharacterLevelFactoryConfiguration();
			config.HitDie = "1d8";
			config.SkillPointsPerLevel = 3;
			config.ClassName = "Strong";
			config.FortitudeSave = new Progression(1, 2, 2, 2, 3, 3, 4, 4, 4, 5);
			config.ReflexSave = new Progression(0, 0, 1, 1, 1, 2, 2, 2, 3, 3);
			config.WillSave = new Progression(0, 0, 1, 1, 1, 2, 2, 2, 3, 3);
			config.AttackBonus = new Progression(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
			config.DefenseBonus = new Progression(1, 2, 2, 3, 3, 3, 4, 4, 5, 5);
			config.ReputationBonus = new Progression(0, 0, 0, 0, 1, 1, 1, 1, 2, 2);

			using (FileStream fs = new FileStream("StrongConfig.xml", FileMode.Truncate))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(CharacterLevelFactoryConfiguration));
				serializer.Serialize(fs, config);
			}
		}

		static void RollHelperTest()
		{
			Console.WriteLine(Environment.NewLine);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("400d20+90 = " + RollHelper.Roll("Dice.Roll(400, 20) + 90"));
		}
	}
}
