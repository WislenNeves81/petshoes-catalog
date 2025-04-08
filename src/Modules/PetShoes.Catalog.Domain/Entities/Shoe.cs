﻿using System;
using Marraia.MongoDb.Core;

namespace PetShoes.Catalog.Domain.Entities
{
    public class Shoe : Entity<Guid>
    {
        public Shoe(string name,
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

            SetDefaultValues();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public List<int> Sizes { get; private set; }
        public bool Active { get; set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public void Update(string name,
                          string description,
                          decimal price,
                          string imageUrl,
                          List<int> sizes,
                          DateTime updatedAt)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            Sizes = sizes;
            UpdatedAt = updatedAt;
        }
        public void UpdatePrice(decimal price)
        {
            Price = price;
            UpdatedAt = DateTime.Now;
        }
        public void UpdateSizes(List<int> sizes)
        {
            Sizes = sizes;
            UpdatedAt = DateTime.Now;
        }
        private void SetDefaultValues()
        {
            Id = Guid.NewGuid();
            Active = true;
        }
    }
}
