using Marraia.MongoDb.Core;

namespace PetShoes.Catalog.Domain.Entities
{
    public class Shoe : Entity<Guid>
    {

        public Shoe(){}
        public Shoe(string brand,
                    string model,
                    string description,
                    double price,
                    string color,
                    string imageUrl)
        {
            Brand = brand;
            Model = model;
            Description = description;
            Price = price;
            Color = color;
            ImageUrl = imageUrl;
            SetDefaultValues();
        }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; private set; }
        public bool Active { get; set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public void Update(string model,
                              string description,
                              double price,
                              string color,
                              string imageUrl)
        {
            Model = model;
            Description = description;
            Price = price;
            Color = color;
            ImageUrl = imageUrl;
            UpdatedAt = DateTime.Now;
        }
        private void SetDefaultValues()
        {
            Id = Guid.NewGuid();
            Active = true;
        }
    }
}
