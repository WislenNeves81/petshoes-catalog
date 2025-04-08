using PetShoes.Catalog.Application.AppShoe.Input;
using PetShoes.Catalog.Application.AppShoe.Interface;
using PetShoes.Catalog.Application.AppShoe.Mapping;
using PetShoes.Catalog.Application.AppShoe.ViewModel;
using PetShoes.Catalog.Domain.Entities;
using PetShoes.Catalog.Domain.Interfaces;

namespace PetShoes.Catalog.Application.AppShoe
{
    public class ShoeAppService : IShoeAppService
    {
        private readonly IShoeRepository _shoeRepository;
        public ShoeAppService(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }
      
        public async Task<ShoeViewModel> InsertAsync(ShoeInput shoeInput)
        {
            var shoe = new Shoe(
               shoeInput.Name,
               shoeInput.Description,
               shoeInput.Brand,
               shoeInput.Price,
               shoeInput.ImageUrl,
               shoeInput.Sizes);

            await _shoeRepository
                        .InsertAsync(shoe)
                        .ConfigureAwait(false);

            return shoe.ToViewModel();
        }
    }
}