/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/10/2007
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YatesMorrison.Rpg
{
	public class Tokenizer
	{
		public void Tokenize(string function)
		{
			string[] tokens = CleanUp(function).Split(' ');
			m_Log.Append("CleanUp(" + function + "): " + CleanUp(function) + Environment.NewLine);

			foreach (string token in tokens)
			{
				if (TokenOperator.IsTokenOperator(token))
				{
					m_tokens.Add(new TokenOperator(token));
				}
				else
				{
					try
					{
						m_tokens.Add(new Token(token));
					}
					catch (Exception ex){ throw new Exception("Problem Tokenizing: " + CleanUp(function), ex); }
				}
			}
		}

		string CleanUp(string function)
		{
			function = FixOperators(function);
			function = Spacify(function);
			return function;
		}

		string FixOperators(string function)
		{
			return function.
				Replace("+-", "-").
				Replace("-+", "-").
				Replace("--", "+").
				Replace("++", "+");			
		}

		string Spacify(string function)
		{
			ArrayList chars = new ArrayList(function.ToCharArray());

			for (int i = 0; i < chars.Count; i++ )
			{
				if (TokenOperator.IsTokenOperator(chars[i].ToString()))
				{
					// Insert a space after TokenOperators
					chars.Insert(i + 1, ' ');

					// Insert a space before TokenOperators
					chars.Insert(i, ' ');

					// Skip the inserted spaces
					i += 2;
				}
			}

			// TODO: Upgrade this code to use .Net30/35 conventions
			StringBuilder output = new StringBuilder();
			foreach (char c in chars)
				output.Append(c);

			return output.ToString(); 
			
			//return new String(chars);
		}

		IList<IToken> m_tokens = new List<IToken>();

		public string Log
		{
			get { return m_Log.ToString(); }
		}
		StringBuilder m_Log = new StringBuilder();

		public double Evaluate()
		{
			double val = 0;
			for (int i = 0; i < m_tokens.Count; i++ )
			{
				if (m_tokens[i] is TokenOperator)
				{
					m_Log.Append("Token[" + i + "]: val = " + val + " " + ((TokenOperator)m_tokens[i]).Type.ToString() + " " + ((Token)m_tokens[i + 1]).Value + Environment.NewLine);
					val = ((TokenOperator)m_tokens[i]).Evaluate(val, ((Token)m_tokens[i + 1]).Value); // i + 1 is already evaluated, move on
					i += 1;
				}
				else
				{
					m_Log.Append("Token[" + i + "]: val = " + ((Token)m_tokens[i]).Value + Environment.NewLine);
					val = ((Token)m_tokens[i]).Value;
				}
			}
			return val;
		}

		/// <summary>
		/// TODO: Refactor this entire class setup to support RollHelper and dropping a particular set of dice out of a roll
		/// </summary>
		public int Evaluate(string function)
		{
			Tokenize(function);
			return (int)Evaluate();
		}
	}

	public class Token : IToken
	{
		public Token(string token)
		{
			Tokenize(token);
		}

		public double Value
		{
			get { return m_value; }
		}
		double m_value = 0;

		public void Tokenize(string token)
		{
			try
			{
				m_value = double.Parse(token);
			}
			catch (FormatException ex) { throw new Exception("Tokenizer error: " + token + " could not be parsed to an double.", ex); }
		}
	}

	public class TokenOperator : IToken
	{
		public TokenOperator( string token )
		{
			Tokenize(token);
		}

		public TokenOperatorType Type
		{
			get { return m_type; }
			set { m_type = value; }
		}
		TokenOperatorType m_type;

		public void Tokenize(string token)
		{
			switch (token.ToLower())
			{
				case "d": m_type = TokenOperatorType.Die; break;
				case "+": m_type = TokenOperatorType.Addition; break;
				case "-": m_type = TokenOperatorType.Subtraction; break;
				case "x": m_type = TokenOperatorType.Multiplication; break;
				case "/": m_type = TokenOperatorType.Subtraction; break;
				default: break;
			}
		}

		public double Evaluate(double left, double right)
		{
			switch( m_type )
			{
				case TokenOperatorType.Die:
					return Dice.Roll((int)System.Math.Round(left), (int)System.Math.Round(right));
				case TokenOperatorType.Addition:
					return left + right;
				case TokenOperatorType.Subtraction:
					return left - right;
				case TokenOperatorType.Multiplication:
					return left * right;
				case TokenOperatorType.Division:
					return left / right;
				default:
					return 0;
			}
		}

		public static bool IsTokenOperator(string token)
		{
			return
				token.ToLower() == "d" ||
				token.ToLower() == "+" ||
				token.ToLower() == "-" ||
				token.ToLower() == "x" ||
				token.ToLower() == "/";
		}
	}

	public interface IToken
	{
		void Tokenize(string token);
	}

	public enum TokenOperatorType
	{
		Die = 0,
		Addition = 1,
		Subtraction = 2,
		Multiplication = 4,
		Division = 8
	}
}