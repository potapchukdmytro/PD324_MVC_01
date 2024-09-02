using PD324_01.Models;

namespace PD324_01.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> Products { get; }
        Task<Product?> GetByIdAsync(int? id);
    }
}
