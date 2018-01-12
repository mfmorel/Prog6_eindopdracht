using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using Prog6.Controllers;
using Prog6.Models;
using Prog6.Respositories;
using Prog6.Respositories.Interfaces;

namespace Prog6
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var composition = new CompositionContainer(catalog);
            IControllerFactory mefControllerFactory = new MefControllerFactory(composition);
            ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);*/
        }

        
    }
}
