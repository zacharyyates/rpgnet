/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/18/2007
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace YatesMorrison.Rpg
{
	public class Progression
	{
		public Progression() { }
		public Progression(params double[] readableFormat)
		{
			CopyFromReadableFormat(readableFormat);
		}

		public string Value
		{
			get { return ToString(ToReadableFormat()); }
			set { CopyFromReadableFormat(ToDoubleArray(value)); }
		}

		List<double> m_SumFormat = new List<double>();
		
		public double GetValue(int index)
		{
			CheckIndex(index);

			return m_SumFormat[index];
		}
		public double GetTotal(int index)
		{
			CheckIndex(index);

			double total = 0;
			for (int step = 0; step < index; step++)
			{
				total += m_SumFormat[step];
			}
			return total;
		}

		/// <summary>
		/// Gets the advancement of the progression from the specified total
		/// </summary>
		/// <returns>Null if the total is not in the progression</returns>
		public int? GetIndex(double total)
		{
			double currentTotal = 0;
			for (int index = 0; index < m_SumFormat.Count; index++)
			{
				currentTotal += m_SumFormat[index];
				if (currentTotal <= total)
				{
					return index;
				}
			}
			return null;
		}

		void CheckIndex(int index)
		{
			if (index >= m_SumFormat.Count)
			{
				throw new IndexOutOfRangeException("Index value: " + index + " does not exist.  Collection size: " + m_SumFormat.Count);
			}
		}

		/// <summary>
		/// Populates the CharacterAttribute.SimpleScore field for progression based attributes.
		/// </summary>
		public void BuildAttributeFor<T>(CharacterLevel level, T attribute)
			where T : CharacterAttribute
		{
			CheckIndex(level.LevelIndex);

			if (m_SumFormat[level.LevelIndex] > 0)
			{
				attribute.SimpleScore = GetValue(level.LevelIndex);
				level.AddAttribute(attribute);
			}
		}

		/// <summary>
		/// Copies a progression array of human readable format values into sum format values. 
		/// i.e.: 0,0,1,1,2,2 = 0,0,1,0,1,0 (the sum of the array's values should equal the last number in the human readable series
		/// </summary>
		public void CopyFromSumFormat(double[] sumFormat)
		{
			m_SumFormat.Clear();
			m_SumFormat.AddRange(sumFormat);
		}
		public void CopyFromReadableFormat(double[] readableFormat)
		{
			m_SumFormat.Clear();
			m_SumFormat.AddRange(ToSumFormat(readableFormat));
		}

		public static double[] ToSumFormat(double[] readableFormat)
		{
			double[] sumFormat = new double[readableFormat.Length];
			double previousStep = 0;
			for (int step = 0; step < readableFormat.Length; step++)
			{
				double currentStep = readableFormat[step];
				double difference = currentStep - previousStep;
				sumFormat[step] = difference;
				previousStep = currentStep;
			}
			return sumFormat;
		}
		public static double[] ToReadableFormat(double[] sumFormat)
		{
			double[] readableFormat = new double[sumFormat.Length];
			double runningTotal = 0;
			for (int step = 0; step < sumFormat.Length; step++)
			{
				runningTotal += sumFormat[step];
				readableFormat[step] = runningTotal;
			}
			return readableFormat;
		}

		public double[] ToSumFormat()
		{
			return m_SumFormat.ToArray();
		}
		public double[] ToReadableFormat()
		{
			return ToReadableFormat(m_SumFormat.ToArray());
		}

		public static string ToString(double[] progression)
		{
			StringBuilder builder = new StringBuilder();
			foreach (double arg in progression)
			{
				builder.AppendFormat("{0}, ", arg);
			}
			string output = builder.ToString();
			return output.Substring(0, output.Length - 2);
		}
		public static double[] ToDoubleArray(string progression)
		{
			List<double> output = new List<double>();
			string[] argArray = progression.
				Replace(" ", "").
				Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string arg in argArray)
			{
				try
				{
					output.Add(double.Parse(arg));
				}
				catch (Exception)
				{
					// Do not add
				}
			}
			return output.ToArray();
		}

		public override string ToString()
		{
			return ToString(ToReadableFormat());
		}
	}
}