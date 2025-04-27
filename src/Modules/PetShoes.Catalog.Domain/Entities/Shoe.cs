using Marraia.MongoDb.Core;

namespace PetShoes.Catalog.Domain.Entities
{
    public class Shoe : Entity<Guid>
    {
        private List<int> sizes;

        public Shoe(string brand,
                    string model,
                    string description,
                    string imageUrl)
        {
            Brand = brand;
            Model = model;
            Description = description;
            ImageUrl = imageUrl;
            SetDefaultValues();
        }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public string ImageUrl { get; private set; }
        public bool Active { get; set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public void Update(string model,
                          string description,
                          string imageUrl)
        {
            Model = model;
            Description = description;
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
