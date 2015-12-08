[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LetsParty.UI.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LetsParty.UI.Web.App_Start.NinjectWebCommon), "Stop")]

namespace LetsParty.UI.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using LetsParty.Infra.Data.Context;
    using LetsParty.Infra.Data.Repository;
    using LetsParty.Domain.Repository;
    using LetsParty.AppService.Usuarios;
    using LetsParty.AppService.Anuncios;
    using LetsParty.AppService.Servicos;
    using LetsParty.AppService.Fotos;
    using LetsParty.AppService.Eventos;
    using LetsParty.AppService.Status;
    using LetsParty.AppService.Log;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILetsPartyContext>().To<LetsPartyContext>().InRequestScope();

            //Repositorio
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IAnuncioRepository>().To<AnuncioRepositorio>();
            kernel.Bind<IServicoRepository>().To<ServicosRepository>();
            kernel.Bind<IFotoRepository>().To<FotoRepository>();
            kernel.Bind<IEventoRepository>().To<EventoRepository>();
            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            kernel.Bind<ILogResository>().To<LogRepository>();

            //Sevicos
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IAnunciosServices>().To<AnunciosServices>();
            kernel.Bind<IServicoServices>().To<ServicoServices>();
            kernel.Bind<IFotoService>().To<FotoService>();
            kernel.Bind<IEventoService>().To<EventoService>();
            kernel.Bind<IStatusService>().To<StatusService>();
            kernel.Bind<IlogService>().To<LogService>();

        }        
    }
}
