/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 2.1.2009
 */
namespace YatesMorrison.Code
{
	using System.CodeDom.Compiler;
	using Microsoft.CSharp;

	public static class CompilerExtensions
	{
		public static void Compile(this string[] source, string outputFileName, bool generateExecutable, bool generateInMemory, params string[] referenceAssemblies)
		{
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			CompilerParameters parameters = new CompilerParameters(referenceAssemblies, outputFileName)
			{
				GenerateExecutable = generateExecutable,
				GenerateInMemory = generateInMemory
			};
			codeProvider.CompileAssemblyFromSource(parameters, source);
		}

		public static void Compile(this string source)
		{
			Compile(new string[] { source }, "YatesMorrison.RuntimeAssembly.dll", false, false, "System.dll");
		}
	}
}