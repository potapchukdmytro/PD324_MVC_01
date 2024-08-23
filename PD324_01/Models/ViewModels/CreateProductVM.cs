using Microsoft.AspNetCore.Mvc.Rendering;

namespace PD324_01.Models.ViewModels
{
    public class CreateProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
