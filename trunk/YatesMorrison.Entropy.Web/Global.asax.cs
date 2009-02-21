namespace YatesMorrison.Entropy.Web
{
	using System.Web.Mvc;
	using System.Web.Routing;
	using YatesMorrison.Data;
	using YatesMorrison.UI;
	using YatesMorrison.Web.Mvc;
	using System;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}

		public static IRepositoryFactory RepositoryFactory
		{
			get { return s_RepositoryFactory; }
		}
		static IRepositoryFactory s_RepositoryFactory = new LinqToSqlRepositoryFactory();

		public static IScaffoldingManager GetScaffoldingManager<T>()
		{
			return new ReflectionScaffoldingManager(typeof(T), ControlFactory);
		} // todo: create a factory for the ScaffoldingManager paradigm?
		public static IScaffoldingManager GetScaffoldingManager(Type type)
		{
			if (type == null) { throw new ArgumentNullException("type"); }
			return new ReflectionScaffoldingManager(type, ControlFactory);
		}
		public static IScaffoldingManager GetScaffoldingManager(string typeName)
		{
			if (string.IsNullOrEmpty(typeName)) { throw new ArgumentNullException("typeName"); }
			return new ReflectionScaffoldingManager(Type.GetType(typeName), ControlFactory);
		}

		public static IControlFactory ControlFactory
		{
			get { return s_ControlFactory; }
		}
		static IControlFactory s_ControlFactory = new MvcControlFactory();
	}
}