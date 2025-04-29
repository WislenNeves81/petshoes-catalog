using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Application.AppShoe.Input
{
    public class ShoeInput
    {
        public ShoeInput(){}
        public ShoeInput(string model,
                        string description,
                        string brand,
                        string imageUrl)
        {
            Model = model;
            Description = description;
            Brand = brand;
            ImageUrl = imageUrl;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
