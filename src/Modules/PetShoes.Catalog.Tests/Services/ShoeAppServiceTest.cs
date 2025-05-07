using Bogus;
using FluentAssertions;
using MyProfit.Foundation.Redis.Repositories.Interfaces;
using NSubstitute;
using PetShoes.Catalog.Application.AppShoe;
using PetShoes.Catalog.Application.AppShoe.Input;
using PetShoes.Catalog.Application.AppShoe.ViewModel;
using PetShoes.Catalog.Domain.Entities;
using PetShoes.Catalog.Domain.Interfaces;

namespace PetShoes.Catalog.Tests.Services.Generate
{
    public class ShoeAppServiceTest
    {
        private ShoeAppService _shoeAppService;
        private IShoeRepository _shoeRepository;
        private Faker _faker;

        private const int defaultReceived = 1;

        public ShoeAppServiceTest()
        {
            _shoeRepository = Substitute.For<IShoeRepository>();
            var cacheRepositoryMock = Substitute.For<ICacheRepository>();
            _shoeAppService = new ShoeAppService(_shoeRepository, cacheRepositoryMock);

            _faker = new Faker();
        }

        [Fact]
        public async Task GetShoeIdAsync_When_Returns_Value()
        {
            //Arrange
            var shoeId = _faker.Random.Guid();
            var shoe = GenerateFakerShoe.CreateShoeObject(shoeId);
            _shoeRepository.GetShoeByIdAsync(Arg.Any<Guid>()).Returns(shoe);

            //Act
            var result = await _shoeAppService.GetShoeByIdAsync(shoeId);

            //Assert
            result.Should().BeOfType<ShoeViewModel>();

            await _shoeRepository
                    .Received(defaultReceived)
                    .GetShoeByIdAsync(Arg.Any<Guid>());
        }
        [Fact]
        public async Task GetShoeIdAsync_When_Do_Not_Returns_Value()
        {
            //Arrange
            var shoeId = _faker.Random.Guid();
            _shoeRepository.GetShoeByIdAsync(Arg.Any<Guid>())!.Returns(default(Shoe));

            //Act
            var result = await _shoeAppService.GetShoeByIdAsync(shoeId);

            //Assert
            result.Should().BeNull();

        }

        [Fact]
        public async Task InsertShoeAsync_When_Model_Exists()
        {
            // Arrange  
            var shoeId = _faker.Random.Guid();
            var shoe = GenerateFakerShoe.CreateShoeObject(shoeId);

            var shoeInput = new ShoeInput()
            {
                Model = shoe.Model,
                Description = shoe.Description,
                Brand = shoe.Brand,
                Price = shoe.Price,
                Color = shoe.Color,
                ImageUrl = shoe.ImageUrl
            };

            _shoeRepository.GetShoeByModelAsync(Arg.Any<string>()).Returns(shoe);

            // Act  
            var result = await _shoeAppService.InsertAsync(shoeInput);

            // Assert  
            result.Should().BeNull();

            await _shoeRepository
                    .Received(defaultReceived)
                    .GetShoeByModelAsync(Arg.Any<string>());

        }
    }
}
