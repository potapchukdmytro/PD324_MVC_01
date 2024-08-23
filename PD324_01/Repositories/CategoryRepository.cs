using PD324_01.Data;
using PD324_01.Models;

namespace PD324_01.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context; 
        }

        public Category? GetById(int id)
        {
            var model = _context.Categories.FirstOrDefault(p => p.Id == id);
            return model;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }
    }
}
