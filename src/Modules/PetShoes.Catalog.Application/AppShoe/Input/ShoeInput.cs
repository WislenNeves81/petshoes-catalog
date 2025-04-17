using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Application.AppShoe.Input
{
    public class ShoeInput
    {
        public ShoeInput(string name,
                        string description,
                        string brand,
                        decimal price,
                        string imageUrl,
                        List<ShoeSizeInput> sizes)
        {
            Name = name;
            Description = description;
            Brand = brand;
            Price = price;
            ImageUrl = imageUrl;
            Sizes = sizes;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<ShoeSizeInput> Sizes { get; private set; }

        public class ShoeSizeInput
        {
            public int Size { get; set; }
            public int Quantity { get; set; }

            public ShoeSizeInput(int size, int quantity)
            {
                Size = size;
                Quantity = quantity;
            }
        }

    }
}
