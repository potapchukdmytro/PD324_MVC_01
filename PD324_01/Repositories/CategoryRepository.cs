using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;

namespace PD324_01.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        public IEnumerable<Category> Categories => GetAll().AsNoTracking();

        public async Task<Category?> GetByIdAsync(int id)
        {
            var model = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return model;
        }
    }
}
