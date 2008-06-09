/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/24/2007
 */

using System;
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;

namespace YatesMorrison.Math.Eval
{
	public class ExpressionParser
	{
		EvaluatorBase m_Evaluator = null;
		public string Errors
		{
			get { return m_Errors.ToString(); }
		}
		StringBuilder m_Errors = null;

		public ExpressionParser() { }
		public ExpressionParser(string expression)
		{
			Initialize(expression);
		}

		/// <summary>
		/// TODO: Implement IDisposable
		/// </summary>
		public bool Initialize(string expression)
		{
			m_Errors = null;
			m_Errors = new StringBuilder();

			CompilerResults compilerResults = null;

			using (CodeDomProvider codeDomProvider = GetCodeDomProvider())
			{
				compilerResults = codeDomProvider.CompileAssemblyFromSource(
					GetCompilerParams(), GetSource(expression));
			}

			foreach (CompilerError error in compilerResults.Errors)
			{
				m_Errors.AppendFormat("Line: {0} Column: {1} -- {2}" + Environment.NewLine, error.Line, error.Column, error.ErrorText);
			}

			if (compilerResults.Errors.Count == 0 && compilerResults.CompiledAssembly != null)
			{
				Type objType = compilerResults.CompiledAssembly.GetType("Evaluator");

				try
				{
					if (objType != null)
					{
						m_Evaluator = Activator.CreateInstance(objType) as EvaluatorBase;
					}
				}
				catch (Exception exception)
				{
					throw new Exception("Exception occured creating instance of Evaluator.", exception);
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public double Eval(params double[] args)
		{
			double value = 0.0;
			if (m_Evaluator != null)
			{
				value = m_Evaluator.Eval(args);
			}
			return value;
		}

		CodeDomProvider GetCodeDomProvider()
		{
			return new CSharpCodeProvider();
		}

		CompilerParameters GetCompilerParams()
		{
			CompilerParameters compilerParams = new CompilerParameters();
			compilerParams.GenerateInMemory = true;
			compilerParams.GenerateExecutable = false;
			compilerParams.ReferencedAssemblies.Add("system.dll");
			compilerParams.ReferencedAssemblies.Add("YatesMorrison.Math.Eval.dll");
			compilerParams.ReferencedAssemblies.Add("YatesMorrison.RolePlay.dll");
			return compilerParams;
		}

		string GetSource(string expression)
		{
			return
				@"	using System;
					using YatesMorrison.Math.Eval;
					using YatesMorrison.RolePlay;
										
					public class Evaluator : EvaluatorBase
					{
						public Evaluator(){}
						public override double Eval(params double[] args)
						{
							return " + expression + @";
						}
					}";
		}

		public static double Eval(string expression, params double[] args)
		{
			ExpressionParser parser = new ExpressionParser(expression);
			return parser.Eval(args);
		}
	}
}