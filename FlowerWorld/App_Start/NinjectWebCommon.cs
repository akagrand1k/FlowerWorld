[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FlowerWorld.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FlowerWorld.App_Start.NinjectWebCommon), "Stop")]

namespace FlowerWorld.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DAL.Repository;
    using DAL.Models;
    using System.Data.Entity;
    using DAL;
    using BL.Service.AuthService;
    using BL.Service.CategoryService;
    using Infrastructure;
    using BL.Service.ProductService;
    using BL.Service.OrderService;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel Kernel { get; private set; }
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices();
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }
        
        private static void RegisterServices()
        {
            Kernel.Bind<IRepository<Product>>().To<GenericRepository<Product>>();
            Kernel.Bind<IRepository<Category>>().To<GenericRepository<Category>>();
            Kernel.Bind<IRepository<Order>>().To<GenericRepository<Order>>();
            Kernel.Bind<IRepository<User>>().To<GenericRepository<User>>();

            Kernel.Bind<IUserService>().To<UserService>();
            Kernel.Bind<IImageService>().To<ImageService>();
            Kernel.Bind<ICategoryService>().To<CategoryService>();
            Kernel.Bind<IProductService>().To<ProductService>();
            Kernel.Bind<IOrderService>().To<OrderService>();

            Kernel.Bind<DbContext>().ToConstructor(_ => new FlowerContext());
        }        
    }
}
