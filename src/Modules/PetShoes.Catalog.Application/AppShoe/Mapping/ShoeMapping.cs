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
                Model = shoe.Model,
                Description = shoe.Description,
                Price = shoe.Price,
                Color = shoe.Color,
                Brand = shoe.Brand,
                ImageUrl = shoe.ImageUrl,
                CreatedAt = shoe.CreatedAt
            };
        }
    }
}
