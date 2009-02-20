/* Zachary Yates
 * Copyright © 2009 YatesMorrison Software Company
 * 2.20.2009
 */
namespace YatesMorrison.Data
{
	using System;
	using System.Configuration;
	using System.Data.Linq;
	// todo: this should probably use the provider pattern
	public class LinqToSqlRepositoryFactory : IRepositoryFactory
	{
		public LinqToSqlRepositoryFactory()
		{
			m_Configuration = ConfigurationManager.GetSection("LinqToSqlRepositoryConfiguration") as LinqToSqlRepositoryConfiguration;
			if (m_Configuration == null) throw new ConfigurationErrorsException("LinqToSqlRepositoryConfiguration section is missing or malformed");
		}

		LinqToSqlRepositoryConfiguration m_Configuration;

		public IRepository<T> Create<T>()
			where T : class, new()
		{
			if (!string.IsNullOrEmpty(m_Configuration.DefaultDataContext))
			{
				Type type = Type.GetType(m_Configuration.DefaultDataContext);
				if (type != null)
				{
					DataContext context = Activator.CreateInstance(type) as DataContext;
					if (context != null)
					{
						IRepository<T> repository = Activator.CreateInstance(typeof(LinqToSqlRepository<T, DataContext>), context) as IRepository<T>;
						if (repository != null)
						{
							return repository;
						}
						else { throw new TypeInitializationException(typeof(LinqToSqlRepository<T, DataContext>).FullName, null); }
					}
					else { throw new TypeInitializationException(type.FullName, null); }
				}
				else { throw new TypeInitializationException(m_Configuration.DefaultDataContext, null); }
			}
			else { throw new ConfigurationErrorsException("DefaultDataContext must be specified in LinqToSqlRepositoryConfiguration"); }
		}
	}

	public class LinqToSqlRepositoryConfiguration : ConfigurationSection
	{
		// todo: expand on this class to make it support a list of types and their associated data contexts, unless there is a dynamic way to figure that out
		[ConfigurationProperty(
			"defaultDataContextType",
			IsRequired = true)]
		public string DefaultDataContext
		{
			get { return this["defaultDataContextType"] as string; }
			set { this["defaultDataContextType"] = value; }
		}
	}
}