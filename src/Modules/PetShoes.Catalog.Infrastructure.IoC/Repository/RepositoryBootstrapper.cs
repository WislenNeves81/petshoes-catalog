using Marraia.MongoDb.Configurations;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Catalog.Domain.Interfaces;
using PetShoes.Catalog.Infrastructure.Repositories.Repository;

namespace PetShoes.Catalog.Infrastructure.IoC.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service)
        {
            service.AddMongoDb();
            service.AddScoped<IShoeRepository, ShoeRespository>();
        }
    }
}
