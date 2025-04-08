using Microsoft.Extensions.DependencyInjection;
using PetShoes.Catalog.Infrastructure.IoC.Application;
using PetShoes.Catalog.Infrastructure.IoC.Repository;

namespace PetShoes.Catalog.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new RepositoryBootstrapper().ChildServiceRegister(services);
            new ApplicationBootstrapper().ChildServiceRegister(services);
        }
    }
}
