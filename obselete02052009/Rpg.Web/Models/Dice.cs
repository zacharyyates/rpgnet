/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/25/2007
 */

using System;
using System.Collections.Generic;

namespace YatesMorrison.Rpg
{
	public static class Dice
	{
		static Dice()
		{
			Seed();
		}

		public static void Seed()
		{
			s_Random = new Random(DateTime.Now.Millisecond);
		}

		internal static Random Random
		{
			get
			{
				if (s_Random == null) { Seed(); }
				return s_Random;
			}
		}
		static Random s_Random;

		/// <summary>
		/// Rolls a single die ie: 1d6, where diceRange = 6
		/// </summary>
		public static double Roll( int? diceRange )
		{
			if (!diceRange.HasValue)
				throw new InvalidOperationException("Parameter diceRange must have a value.");

			return Random.Next(1, diceRange.Value + 1);
		}
		/// <summary>
		/// Rolls a single die ie: 1d6, where diceRange = 6
		/// </summary>
		public static double Roll( DieType die )
		{
			return Roll((int)die);
		}

		/// <summary>
		/// Rolls any number of dice, ie: 2d10 where diceNumber = 4 and diceRange = 10
		/// </summary>
		internal static double Roll( int? diceNumber, int? diceRange, DieRollMechanicDelegate rollMechanic )
		{
			if (!diceNumber.HasValue)
				throw new InvalidOperationException("Parameter diceNumber must have a value.");

			double total = 0;

			for (int i = 0; i < diceNumber.Value; i++)
			{
				total += rollMechanic(diceRange);
			}

			return total;
		}
		/// <summary>
		/// Rolls any number of dice, ie: 4d10 where diceNumber = 4 and diceRange = 10
		/// </summary>
		public static double Roll( int? diceNumber, int? diceRange )
		{
			return Roll(diceNumber, diceRange, Roll);
		}
		/// <summary>
		/// Rolls any number of dice, ie: 4d10 where diceNumber = 4 and dieType = d10
		/// </summary>
		public static double Roll( int? diceNumber, DieType die )
		{
			return Roll(diceNumber, (int)die);
		}

		/// <summary>
		/// Rolls any number of dice, and performs special operations based on the dieRollOptions parameter; ie: 4d6 where diceNumber = 4 and diceRange = 10
		/// </summary>
		internal static double Roll( int? diceNumber, int? diceRange, DieRollMechanicDelegate rollMechanic, params DieRollOptions[] dieRollOptions )
		{
			if (!diceNumber.HasValue)
				throw new InvalidOperationException("Parameter diceNumber must have a value.");

			List<DieRollOptions> options = new List<DieRollOptions>(dieRollOptions);

			List<double> rollResults = new List<double>();

			for (int index = 0; index < diceNumber; index++)
			{
				double dieRoll = rollMechanic(diceRange);
				while (IsRerollNumber(options, dieRoll))
				{
					dieRoll = rollMechanic(diceRange);
				}
				rollResults.Add(dieRoll);
			}

			// Drop Lowest
			DieRollOptions dropLowestOption = options.Find(
				new Predicate<DieRollOptions>(delegate( DieRollOptions predicateOptions )
				{
					return (predicateOptions.OptionType == DieRollOptionType.DropLowest);
				}));

			if (dropLowestOption != null)
			{
				for (int dropHowMany = 0; dropHowMany < dropLowestOption.Value; dropHowMany++)
				{
					// TODO: Consider replacing with LINQ
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
				new Predicate<DieRollOptions>(delegate( DieRollOptions predicateOptions )
				{
					return (predicateOptions.OptionType == DieRollOptionType.DropHighest);
				}));

			if (dropHighestOption != null)
			{
				for (int dropHowMany = 0; dropHowMany < dropLowestOption.Value; dropHowMany++)
				{
					// TODO: Consider replacing with LINQ
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
		/// <summary>
		/// Rolls any number of dice, and performs special operations based on the dieRollOptions parameter; ie: 4d6 where diceNumber = 4 and diceRange = 10
		/// </summary>
		public static double Roll( int? diceNumber, int? diceRange, params DieRollOptions[] dieRollOptions )
		{
			return Roll(diceNumber, diceRange, Roll, dieRollOptions);
		}
		/// <summary>
		/// Rolls any number of dice, and performs special operations based on the dieRollOptions parameter; ie: 4d6 where diceNumber = 4 and diceRange = 10
		/// </summary>
		public static double Roll( int? diceNumber, DieType die, params DieRollOptions[] dieRollOptions )
		{
			return Roll(diceNumber, (int)die, Roll, dieRollOptions);
		}
		
		public static double Max( int? diceRange )
		{
			if (!diceRange.HasValue)
				throw new InvalidOperationException("Parameter diceRange must have a value.");

			return (double)diceRange.Value;
		}
		public static double Max( DieType die )
		{
			return Roll((int)die);
		}

		public static double Max( int? diceNumber, int? diceRange )
		{
			return Roll(diceNumber, diceRange, Max);
		}
		public static double Max( int? diceNumber, DieType die )
		{
			return Max(diceNumber, (int)die);
		}

		public static double Max( int? diceNumber, int? diceRange, params DieRollOptions[] dieRollOptions )
		{
			return Roll(diceNumber, diceRange, Max, dieRollOptions);
		}
		public static double Max( int? diceNumber, DieType die, params DieRollOptions[] dieRollOptions )
		{
			return Roll(diceNumber, (int)die, dieRollOptions);
		}

		static bool IsRerollNumber( List<DieRollOptions> options, double dieRoll )
		{
			List<DieRollOptions> rerollOptions = options.FindAll(
				new Predicate<DieRollOptions>(delegate( DieRollOptions predicateOptions )
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
	}

	internal delegate double DieRollMechanicDelegate( int? diceRange );

	public class DieRollOptions
	{
		public DieRollOptions( DieRollOptionType optionType, int value )
		{
			OptionType = optionType;
			Value = value;
		}

		public DieRollOptionType OptionType { get; set; }

		public double Value { get; set; }

		public static readonly DieRollOptions RerollOnes = new DieRollOptions(DieRollOptionType.ReRoll, 1);
		public static readonly DieRollOptions RerollTwos = new DieRollOptions(DieRollOptionType.ReRoll, 2);
		public static readonly DieRollOptions DropLowestOne = new DieRollOptions(DieRollOptionType.DropLowest, 1);
		public static readonly DieRollOptions DropLowestTwo = new DieRollOptions(DieRollOptionType.DropLowest, 2);
		public static readonly DieRollOptions DropHighestOne = new DieRollOptions(DieRollOptionType.DropHighest, 1);
		public static readonly DieRollOptions DropHighestTwo = new DieRollOptions(DieRollOptionType.DropHighest, 2);
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