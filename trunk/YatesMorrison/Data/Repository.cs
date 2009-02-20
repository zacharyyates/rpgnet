/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.18.2009
 */
namespace YatesMorrison.Data
{
	using System;
	using System.Data.Linq;
	using System.Linq;
	using System.Linq.Expressions;

	public interface IRepository<T>
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

	public class Repository<T, C> : IRepository<T>, IDisposable
		where T : class
		where C : DataContext
	{
		public Repository(C context)
		{
			m_Context = context;
		}

		C m_Context;

		protected virtual Table<T> Table
		{
			get { return m_Context.GetTable<T>(); }
		}

		public IQueryable<T> All()
		{
			return Table;
		}
		public IQueryable<T> All(Expression<Func<T, bool>> predicate)
		{
			return Table.Where(predicate);
		}

		public T Single(Expression<Func<T, bool>> predicate)
		{
			return Table.Single(predicate);
		}
		public T First(Expression<Func<T, bool>> predicate)
		{
			return Table.First(predicate);
		}
		public T FirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			return Table.FirstOrDefault(predicate);
		}

		public T Create()
		{
			T entity = default(T);
			Table.InsertOnSubmit(entity);
			return entity;
		}
		
		public void Update(T entity){
			// todo: figure out what to do with this
		}
		public void Delete(T entity)
		{
			Table.DeleteOnSubmit(entity);
		}

		public void SubmitChanges()
		{
			m_Context.SubmitChanges();
		}

		#region IDisposable
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_Context.Dispose();
				m_Context = null;
			}
		}
		#endregion
	}
}