using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Catalog.Infrastructure.IoC.Application;
using PetShoes.Catalog.Infrastructure.IoC.Repository;

namespace PetShoes.Catalog.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            new RepositoryBootstrapper().ChildServiceRegister(services, configuration);
            new ApplicationBootstrapper().ChildServiceRegister(services);
        }
    }
}
