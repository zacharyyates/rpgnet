﻿/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.5.2009
 */
using System.Collections.ObjectModel;

namespace YatesMorrison.RolePlay
{
	public interface IParentOf<T>
		where T : class
	{
		void Add(T child);
		void Remove(T child);
	}

	public interface IChildOf<T>
		where T : class
	{
		void AddTo(T parent);
		void RemoveFrom(T parent);
	}
}