/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/12/2007
 */

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using YatesMorrison.RolePlay.D20;
using System.Diagnostics;

namespace YatesMorrison.RolePlay.Test
{
	public class TextCharacterVisualizer : ICharacterVisualizer
	{
		public void Visualize( Character character, Stream outputStream )
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Visualize( Character character, StringBuilder output )
		{
			output.AppendFormat("{0}" + Environment.NewLine, character.Name);
			output.AppendFormat("Level {0} Hero" + Environment.NewLine, character.Levels.Count);
			foreach( string ability in GetAbilityNames() )
			{
				output.AppendFormat("{0}:\t{1}\t{2}" + Environment.NewLine,
					ability,
					character.GetEffectedScoreFor(ability),
					character.GetEffectedScoreFor(ability + " Modifier"));
			}

			Debug.Assert(character.HasAttribute("Base Attack Bonus"), "Attack bonus not found");
			output.AppendFormat("AtkBns: {0}" + Environment.NewLine,
				character.GetEffectedScoreFor("Base Attack Bonus"));

			Debug.Assert(character.HasAttribute("Hit Points"), "HP attrib not found");
			output.AppendFormat("HP: {0}" + Environment.NewLine,
				character.GetEffectedScoreFor("Hit Points"));

			Debug.Assert(character.HasAttribute("Reputation Bonus"), "Rep not found");
			output.AppendFormat("Rep: {0}" + Environment.NewLine,
				character.GetEffectedScoreFor("Reputation Bonus"));

			Debug.Assert(character.HasAttribute("Wealth Bonus"), "Attack bonus not found");
			output.AppendFormat("WealthBns: {0}" + Environment.NewLine,
				character.GetEffectedScoreFor("Wealth Bonus"));
		}

		public static string[] GetAbilityNames()
		{
			return new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
		}
		public static string[] GetSavingThrowNames()
		{
			return new string[] { "Fortitude Save", "Reflex Save", "Will Save" };
		}
	}
}
