/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.18.2009
 */
namespace YatesMorrison.Data
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;

	public interface IRepository<T> : IDisposable
		where T : class
	{
		IQueryable<T> All();
		IQueryable<T> All(Expression<Func<T, bool>> predicate);

		T Single(Expression<Func<T, bool>> predicate);
		T First(Expression<Func<T, bool>> predicate);
		T FirstOrDefault(Expression<Func<T, bool>> predicate);

		T Create();
		void Update(T entity);
		void Delete(T entity);

		void SubmitChanges();
	}
}