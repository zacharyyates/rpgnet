﻿/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/25/2007
 */
namespace YatesMorrison.RolePlay
{
	using System;
	using System.Collections.Generic;

	public static class Dice
	{
		static Dice() { }

		static Random Random
		{
			get
			{
				if (s_Random == null) s_Random = new Random();
				return s_Random;
			}
		}
		static Random s_Random;

		// todo: consider changing all of these return values to int
		/// <summary>
		/// Rolls a single die ie: 1d6, where diceRange = 6
		/// </summary>
		public static double Roll(int? diceRange)
		{
			if (!diceRange.HasValue)
				throw new InvalidOperationException("Parameter diceRange must have a value.");

			return Random.Next(1, diceRange.Value + 1);
		}
		public static double Roll(DieType die)
		{
			return Roll((int)die);
		}

		/// <summary>
		/// Rolls any number of dice, ie: 2d10 where diceNumber = 4 and diceRange = 10
		/// </summary>
		public static double Roll(int? diceNumber, int? diceRange)
		{
			if (!diceNumber.HasValue)
				throw new InvalidOperationException("Parameter diceNumber must have a value.");

			double total = 0;

			for (int i = 0; i < diceNumber.Value; i++)
			{
				total += Roll(diceRange);
			}

			return total;
		}
		public static double Roll(int? diceNumber, DieType die)
		{
			return Roll(diceNumber, (int)die);
		}

		/// <summary>
		/// Rolls any number of dice, and performs special operations based on the dieRollOptions parameter; ie: 4d6 where diceNumber = 4 and diceRange = 10
		/// </summary>
		public static double Roll(int? diceNumber, int? diceRange, params DieRollOptions[] dieRollOptions)
		{
			if (!diceNumber.HasValue)
				throw new InvalidOperationException("Parameter diceNumber must have a value.");

			List<DieRollOptions> options = new List<DieRollOptions>(dieRollOptions);

			List<double> rollResults = new List<double>();

			for (int index = 0; index < diceNumber; index++)
			{
				double dieRoll = Roll(diceRange);
				while (IsRerollNumber(options, dieRoll))
				{
					dieRoll = Roll(diceRange);
				}
				rollResults.Add(dieRoll);
			}

			// Drop Lowest
			DieRollOptions dropLowestOption = options.Find(
				new Predicate<DieRollOptions>(delegate(DieRollOptions predicateOptions)
				{
					return (predicateOptions.OptionType == DieRollOptionType.DropLowest);
				}));

			if (dropLowestOption != null)
			{
				for (int dropHowMany = 0; dropHowMany < dropLowestOption.Value; dropHowMany++)
				{
					double lowest = diceRange.Value + 1;
					for (int index = 0; index < rollResults.Count; index++)
					{
						if (rollResults[index] < lowest)
						{
							lowest = rollResults[index];
						}
					}
					rollResults.Remove(lowest);
				}
			}

			// Drop Highest
			DieRollOptions dropHighestOption = options.Find(
				new Predicate<DieRollOptions>(delegate(DieRollOptions predicateOptions)
				{
					return (predicateOptions.OptionType == DieRollOptionType.DropHighest);
				}));

			if (dropHighestOption != null)
			{
				for (int dropHowMany = 0; dropHowMany < dropLowestOption.Value; dropHowMany++)
				{
					double highest = -1;
					for (int index = 0; index < rollResults.Count; index++)
					{
						if (rollResults[index] > highest)
						{
							highest = rollResults[index];
						}
					}
					rollResults.Remove(highest);
				}
			}

			double total = 0;
			foreach (double roll in rollResults)
			{
				total += roll;
			}
			return total;
		}
		public static double Roll(int? diceNumber, DieType die, params DieRollOptions[] dieRollOptions)
		{
			return Roll(diceNumber, (int)die, dieRollOptions);
		}

		static bool IsRerollNumber(List<DieRollOptions> options, double dieRoll)
		{
			List<DieRollOptions> rerollOptions = options.FindAll(
				new Predicate<DieRollOptions>(delegate(DieRollOptions predicateOptions)
				{
					return (predicateOptions.OptionType == DieRollOptionType.ReRoll);
				}));

			if (rerollOptions.Count > 0)
			{
				foreach (DieRollOptions rerollOption in rerollOptions)
				{
					if (rerollOption.Value == dieRoll)
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Returns a random number in the given range
		/// </summary>
		public static double Range(int? min, int? max)
		{
			if (!min.HasValue || !max.HasValue)
				throw new InvalidOperationException("Parameters min, max must both have values.");

			return Random.Next(min.Value, max.Value);
		}
	}

	public class DieRollOptions
	{
		public DieRollOptions(DieRollOptionType optionType, int value)
		{
			OptionType = optionType;
			Value = value;
		}

		public DieRollOptionType OptionType
		{
			get { return m_OptionType; }
			set { m_OptionType = value; }
		}
		DieRollOptionType m_OptionType = DieRollOptionType.DropLowest;

		public double Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		double m_Value = 0;
	}

	public enum DieRollOptionType
	{
		ReRoll,
		DropLowest,
		DropHighest
	}

	public enum DieType : int
	{
		D4 = 4,
		D6 = 6,
		D8 = 8,
		D10 = 10,
		D12 = 12,
		D20 = 20,
		D100 = 100
	}
}