using Marraia.MongoDb.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfit.Foundation.Redis.Configurations;
using PetShoes.Catalog.Domain.Interfaces;
using PetShoes.Catalog.Infrastructure.Repositories.Repository;

namespace PetShoes.Catalog.Infrastructure.IoC.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service, IConfiguration configuration)
        {
            service.AddMongoDb();
            service.AddRedis(configuration);
            service.AddScoped<IShoeRepository, ShoeRespository>();
        }
    }
}
