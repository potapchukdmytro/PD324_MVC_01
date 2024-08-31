using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;

namespace PD324_01.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products => GetAll()
            .AsNoTracking()
            .Include(p => p.Category);
    }
}
