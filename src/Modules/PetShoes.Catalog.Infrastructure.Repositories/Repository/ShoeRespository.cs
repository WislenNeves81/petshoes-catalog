using Marraia.MongoDb.Repositories;
using Marraia.MongoDb.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
        public async Task<Shoe> GetShoeByIdAsync(Guid itemCatalogId)
        {
            return await Collection
                            .AsQueryable()
                            .Where(item => item.Id == itemCatalogId && item.Active == true)
                            .FirstOrDefaultAsync();
        }
        public async Task<List<Shoe>> GetAllAsync()
        {
            return await Collection
                            .AsQueryable()
                            .Where(item => item.Active == true)
                            .ToListAsync();
        }
        public async Task<Shoe> UpdateAsync(Shoe itemCatalog)
        {
            await Collection
                   .ReplaceOneAsync(c => c.Id == itemCatalog.Id, itemCatalog)
                   .ConfigureAwait(false);

            return itemCatalog;
        }
        public async Task DeleteAsync(Guid itemCatalogId)
        {
            await Collection
                    .UpdateOneAsync(c => c.Id == itemCatalogId,
                                    Builders<Shoe>.Update.Set(itemCatalog => itemCatalog.Active, false))
                    .ConfigureAwait(false);
        }
    }
}
