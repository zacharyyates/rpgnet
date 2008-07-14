/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/13/2008
 */

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Rpg.Web.Models
{
	public interface IRepository<T>
		where T : class
	{
		IEnumerable<T> All();
		IEnumerable<T> All( Func<T, bool> exp );
		T Single( Func<T, bool> exp );
		T First( Func<T, bool> exp );
		void DeleteOnSubmit( T entity );
		T New();
		void SubmitChanges();
	}

	public class Repository<T> : IRepository<T>
		where T : class
	{
		public Repository( DataContext context )
		{
			m_Context = context;
		}

		protected C GetContext<C>()
			where C : DataContext
		{
			return m_Context as C;
		}
		DataContext m_Context;

		public IEnumerable<T> All()
		{
			return Table;
		}

		public IEnumerable<T> All( Func<T, bool> exp )
		{
			return Table.Where(exp);
		}

		public T Single( Func<T, bool> exp )
		{
			return Table.Single(exp);
		}

		public T First( Func<T, bool> exp )
		{
			return Table.First(exp);
		}

		public void DeleteOnSubmit( T entity )
		{
			Table.DeleteOnSubmit(entity);
		}

		public T New()
		{
			T entity = Activator.CreateInstance<T>();
			Table.InsertOnSubmit(entity);
			return entity;
		}

		protected Table<T> Table
		{
			get { return GetContext<DataContext>().GetTable<T>(); }
		}

		public void SubmitChanges()
		{
			GetContext<DataContext>().SubmitChanges();
		}

		public IEnumerable<string> PrimaryKeys
		{
			get 
			{
				foreach (var member in MetaTable.RowType.IdentityMembers)
				{
					yield return member.Name;
				}
			}
		}

		protected MetaTable MetaTable
		{
			get { return GetContext<DataContext>().Mapping.GetTable(typeof(T)); }
		}

		protected MetaType MetaType
		{
			get { return GetContext<DataContext>().Mapping.GetMetaType(typeof(T)); }
		}
	}

	public class Repository<T, C> : Repository<T>
		where T : class
		where C : DataContext
	{
		public Repository( C context ) : base(context) { }

		protected C Context
		{
			get { return GetContext<C>(); }
		}
	}
}