using System.ComponentModel.DataAnnotations;

namespace PD324_01.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
