namespace PetShoes.Catalog.Application.AppShoe.ViewModel
{
    public class ShoeViewModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
