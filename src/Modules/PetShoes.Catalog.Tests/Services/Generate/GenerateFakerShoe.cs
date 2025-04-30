using Bogus;
using PetShoes.Catalog.Domain.Entities;

namespace PetShoes.Catalog.Tests.Services.Generate
{
    public class GenerateFakerShoe
    {
        private const string UtfType = "pt_BR";
        private const int IntEight = 8;

        public static Shoe CreateShoeObject(Guid id)
        {
            var faker = new Faker<Shoe>(UtfType)
                                .StrictMode(true)
                                .RuleFor(c => c.Id, id)
                                .RuleFor(c => c.Brand, faker => faker.Commerce.ProductAdjective())
                                .RuleFor(c => c.Model, faker => faker.Commerce.ProductName())
                                .RuleFor(c => c.Description, faker => faker.Lorem.Paragraphs(IntEight))
                                .RuleFor(c => c.ImageUrl, faker => faker.Internet.Avatar())
                                .RuleFor(c => c.Active, faker => faker.Random.Bool())
                                .RuleFor(c => c.CreatedAt, faker => faker.Date.Past())
                                .RuleFor(c => c.UpdatedAt, faker => faker.Date.Past());
            return faker.Generate();
        }
    }
}   
