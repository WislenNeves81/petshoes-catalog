using PetShoes.Catalog.Application.AppShoe.Input;
using PetShoes.Catalog.Application.AppShoe.ViewModel;

namespace PetShoes.Catalog.Application.AppShoe.Interface
{
    public interface IShoeAppService
    {
        Task<ShoeViewModel> InsertAsync(ShoeInput shoeInput);
        Task<ShoeViewModel> GetShoeByIdAsync(Guid id);
        Task<List<ShoeViewModel>> GetAllAsync();
        Task<ShoeViewModel> UpdateAsync(Guid id, ShoeInput shoeInput);
        Task DeleteAsync(Guid id);


    }
}