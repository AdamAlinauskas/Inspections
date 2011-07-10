using Inspections.Controllers;
using Ninject.Modules;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Inspections.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Inspections.App_Start.NinjectMVC3), "Stop")]

namespace Inspections.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new QueryModule());
            //kernel.Bind<IInspectionQuery>().To<InspectionQuery>();
        }        
    }


    public class QueryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IInspectionQuery>().To<InspectionQuery>();
        }
    }
}
