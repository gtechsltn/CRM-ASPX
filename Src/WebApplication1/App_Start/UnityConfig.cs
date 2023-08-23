using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication1.Infrastructure;

namespace WebApplication1
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/dependency-injection-in-asp-net-mvc-5/
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICryptoService, CryptoService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}