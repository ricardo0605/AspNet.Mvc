using Application.Interfaces;
using Application.Services;
using Data.Repository;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using SimpleInjector;

namespace IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            // Application
            container.Register<IRegistryApplicationService, RegistryApplicationService>();

            // Domain
            container.Register<IRegistryService, RegistryService>();

            // Data
            container.Register<IRegistryRepository, RegistryRepository>();
        }
    }
}
