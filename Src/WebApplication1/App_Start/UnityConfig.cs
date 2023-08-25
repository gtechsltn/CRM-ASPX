using System.Web.Http;
using System.Web.Mvc;
using Unity;
using WebApplication1.Business;
using WebApplication1.DataAccess;
using WebApplication1.Infrastructure;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICryptoService, CryptoService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IAccountDataAccess, AccountDataAccess>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICustomerDataAccess, CustomerDataAccess>();

            // Using Unity.Mvc5 and Unity.WebApi together in a project
            // https://www.devtrends.co.uk/blog/using-unity.mvc5-and-unity.webapi-together-in-a-project
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}