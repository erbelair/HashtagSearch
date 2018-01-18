using DryIoc;
using DryIoc.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TwitterClientLibrary;
using TwitterClientLibrary.Services;

namespace HashtagSearch
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new Container();
			container.Register<TwitterClient>(Reuse.Scoped);
			container.Register<ISearchService, SearchService>();
			container.WithMvc();
		}
	}
}
