using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Application.AppShoe.Input
{
    public class ShoeInput
    {
        public ShoeInput(){}
        public ShoeInput(string model,
                            string description,
                            string brand,
                            double price,
                            string color,
                            string imageUrl)
        {
            Model = model;
            Description = description;
            Brand = brand;
            Price = price;
            Color = color;
            ImageUrl = imageUrl;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
    }
}
