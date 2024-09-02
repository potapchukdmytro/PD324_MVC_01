namespace PD324_01.Models.ViewModels
{
    public class ProductDetailsVM
    {
        public ProductDetailsVM() 
        {
            Product = new Product();
        }

        public Product Product { get; set; }
        public bool IsInCart { get; set; }
    }
}
