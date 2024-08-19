using PD324_01.Data;
using PD324_01.Models;

namespace PD324_01.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context; 
        }

        public Product? GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}
