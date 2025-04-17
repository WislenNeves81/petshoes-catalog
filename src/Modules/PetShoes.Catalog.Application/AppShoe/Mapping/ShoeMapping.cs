using PetShoes.Catalog.Application.AppShoe.ViewModel;
using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Application.AppShoe.Mapping
{
    public static class ShoeMapping
    {
        public static ShoeViewModel ToViewModel(this Shoe shoe)
        {
            return new ShoeViewModel
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Description = shoe.Description,
                Brand = shoe.Brand,
                Price = shoe.Price,
                ImageUrl = shoe.ImageUrl,
                Sizes = shoe.Sizes?.Select(size => new ShoeSizeViewModel
                {
                    Size = size.Size,
                    Quantity = size.Quantity
                }).ToList() ?? new List<ShoeSizeViewModel>(),
                CreatedAt = shoe.CreatedAt
            };
        }
    }
}
