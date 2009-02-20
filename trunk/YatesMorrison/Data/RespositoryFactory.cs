/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.Data
{
	using System;
	using System.Configuration;

	public interface IRepositoryFactory
	{
		IRepository<T> Create<T>() where T : class, new();
	}
}