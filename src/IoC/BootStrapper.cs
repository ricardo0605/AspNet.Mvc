using Application.Interfaces;
using Application.Services;
using Data.Context;
using Data.Repository;
using Data.UnitOfWork;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using SimpleInjector;

namespace IoC
{
    public class BootStrapper
    {
        /*
         * Lifestyle.Transient => one instance for each solicitation
         * Lifestyle.Singleton => one unique instance for a class (attention: it is available for the server)
         * Lifestyle.Scoped => one instance for each request
         */

        public static void Register(Container container)
        {
            // Application
            container.Register<IRegistryApplicationService, RegistryApplicationService>(Lifestyle.Scoped);

            // Domain
            container.Register<IRegistryService, RegistryService>(Lifestyle.Scoped);

            // Data
            container.Register<IRegistryRepository, RegistryRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ApplicationContext>(Lifestyle.Scoped);
        }
    }
}
