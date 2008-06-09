/* Zachary Yates
 * Copyright © 2008 YatesMorrison Software, LLC.
 * 01.31.2008
 */

using System;
namespace YatesMorrison.RolePlay.BattleFramework
{
	public class ValueChangedEventArgs<T> : EventArgs
	{
		public T New
		{
			get;
			set;
		}

		public T Old
		{
			get;
			set;
		}
	}
}