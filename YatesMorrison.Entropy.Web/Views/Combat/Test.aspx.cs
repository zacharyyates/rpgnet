/* Zachary Yates
 * Copyright 2009 YatesMorrison Software Company
 * 2.3.2009
 */
namespace YatesMorrison.Entropy.Web.Views.Combat
{
	using System.Web.Mvc;

	public class CombatResult
	{
		public YatesMorrison.Entropy.Character Initiator { get; set; }
		public YatesMorrison.Entropy.Character Target { get; set; }
	}

	public partial class Test : ViewPage<CombatResult>
	{

	}
}
