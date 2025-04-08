using Marraia.MongoDb.Repositories;
using Marraia.MongoDb.Repositories.Interfaces;
using PetShoes.Catalog.Domain.Entities;
using PetShoes.Catalog.Domain.Interfaces;

namespace PetShoes.Catalog.Infrastructure.Repositories.Repository
{
    public class ShoeRespository : MongoDbRepositoryStandard<Shoe, Guid>, IShoeRepository
    {
        public ShoeRespository(IMongoContext context) : base(context) { }

        public async Task InsertAsync(Shoe shoe)
        {
            await Collection
                  .InsertOneAsync(shoe)
                  .ConfigureAwait(false);
        }
    }
}
