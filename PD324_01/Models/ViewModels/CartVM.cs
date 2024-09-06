namespace PD324_01.Models.ViewModels
{
    public class CartVM
    {
        public Product Product { get; set; } = new();
        public int Quantity { get; set; } = 1;
    }
}
