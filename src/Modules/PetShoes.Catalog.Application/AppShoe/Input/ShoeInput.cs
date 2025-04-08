namespace PetShoes.Catalog.Application.AppShoe.Input
{
    public class ShoeInput
    {
        public ShoeInput(string name,
                        string description,
                        string brand,
                        decimal price,
                        string imageUrl,
                        List<int> sizes)
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
        public List<int> Sizes { get; set; }

    }
}
