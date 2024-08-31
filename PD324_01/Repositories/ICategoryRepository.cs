using PD324_01.Models;
using System.Collections;

namespace PD324_01.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<Category> Categories { get; }
        Task<Category?> GetByIdAsync(int id);
    }
}
