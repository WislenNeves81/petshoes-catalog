namespace PetShoes.Catalog.Application.AppShoe.ViewModel
{
    public class ShoeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<ShoeSizeViewModel> Sizes { get; set; } = new List<ShoeSizeViewModel>();
        public DateTime CreatedAt { get; set; }
    }

    public class ShoeSizeViewModel
    {
        public int Size { get; set; }
        public int Quantity { get; set; }
    }
}
