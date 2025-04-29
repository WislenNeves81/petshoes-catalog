using MongoDB.Driver;
using MyProfit.Foundation.Redis.Repositories.Interfaces;
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
        private readonly ICacheRepository _cacheRepository;
        public ShoeAppService(IShoeRepository shoeRepository,
                                ICacheRepository cacheRepository)
        {
            _shoeRepository = shoeRepository;
            _cacheRepository = cacheRepository;

        }
      
        public async Task<ShoeViewModel> InsertAsync(ShoeInput shoeInput)
        {

            var shoe = new Shoe(shoeInput.Model,
                                shoeInput.Description,
                                shoeInput.Brand,
                                shoeInput.ImageUrl);

            await _shoeRepository
                        .GetShoeByModelAsync(shoeInput.Model)
                        .ConfigureAwait(false);

            if (shoe is not null)
                return default!;

            await _shoeRepository
                    .InsertAsync(shoe)
                    .ConfigureAwait(false);

            var shoeViewModel = shoe.ToViewModel();

            var keyShoeCatalog = $"Catalog :: ID: {shoe.Id} - BRAND: {shoe.Brand}";

            await _cacheRepository
                     .InsertAsync<ShoeViewModel>(keyShoeCatalog, shoeViewModel)
                     .ConfigureAwait(false);

            return shoeViewModel;
        }

        public async Task<ShoeViewModel> GetShoeByIdAsync(Guid itemCatalogId)
        {
            var shoe = await _shoeRepository
                                    .GetShoeByIdAsync(itemCatalogId)
                                    .ConfigureAwait(false);
            if (shoe is null)
                return default!;

            return shoe.ToViewModel();
        }

        public async Task<ShoeViewModel> GetShoeByModelAsync(string model)
        {
            var shoe = await _shoeRepository
                                    .GetShoeByModelAsync(model)
                                    .ConfigureAwait(false);
            if (shoe is null)
                return default!;
            
            return shoe.ToViewModel(); 
        }
        public async Task<ShoeViewModel> UpdateAsync(Guid itemCatalogId, ShoeInput shoeInput)
        {
            var itemCatalog = await _shoeRepository
                                        .GetShoeByIdAsync(itemCatalogId)
                                        .ConfigureAwait(false);

            if (itemCatalog == null)
                throw new Exception("Produto não encontrado");

            itemCatalog.Update(shoeInput.Description,
                               shoeInput.Brand,
                               shoeInput.ImageUrl);

            await _shoeRepository
                        .UpdateAsync(itemCatalog)
                        .ConfigureAwait(false);

            return itemCatalog.ToViewModel();
        }
        public async Task DeleteAsync(Guid itemCatalogId)
        {
            var shoe = await _shoeRepository
                                .GetShoeByIdAsync(itemCatalogId)
                                .ConfigureAwait(false);
            if (shoe == null)
                throw new Exception("Produto não encontrado");

            await _shoeRepository
                        .DeleteAsync(itemCatalogId)
                        .ConfigureAwait(false);

        }
    }
}