using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using StandardApp.DataAccess;
using StandardApp.Model.Entities;

namespace StandardApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IGenericRepository<Person>, GenericRepository<Person>>();
            container.RegisterType<IGenericRepository<Order>, GenericRepository<Order>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}