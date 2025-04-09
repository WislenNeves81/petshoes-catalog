using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Domain.Interfaces
{
    public interface IShoeRepository
    {
        Task InsertAsync(Shoe shoe);
        Task<Shoe> GetShoeByIdAsync(Guid itemCatalogId);
        Task<List<Shoe>> GetAllAsync();
        Task<Shoe> UpdateAsync(Shoe itemCatalog);
        Task DeleteAsync(Guid itemCatalogId);

    }
}
