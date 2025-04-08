using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Domain.Interfaces
{
    public interface IShoeRepository
    {
        Task InsertAsync(Shoe shoe);
    }
}
