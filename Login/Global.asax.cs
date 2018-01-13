using WebDBApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebDBApp.Helpers;
using WebDBApp.DAL;

namespace WebDBApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterUnityContainer();
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Messages";
            DefaultModelBinder.ResourceClassKey = "Messages";
            
        }

        private void RegisterUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IHashHelper, SHA256HashHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
