using PD324_01.Data;

namespace PD324_01.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel>
        where TModel : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(TModel model)
        {
            await _context.AddAsync(model);   
            var res = await _context.SaveChangesAsync();
            return res != 0;
        }

        public IQueryable<TModel> GetAll()
        {
            return _context.Set<TModel>();
        }

        public async Task<bool> RemoveAsync(TModel model)
        {
            _context.Remove(model);
            var res = await _context.SaveChangesAsync();
            return res != 0;
        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            _context.Update(model);
            var res = await _context.SaveChangesAsync();
            return res != 0;
        }
    }
}
