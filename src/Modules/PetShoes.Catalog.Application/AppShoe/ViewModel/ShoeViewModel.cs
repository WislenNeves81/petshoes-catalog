namespace PetShoes.Catalog.Application.AppShoe.ViewModel
{
    public class ShoeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string  Brand { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<int> Sizes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
