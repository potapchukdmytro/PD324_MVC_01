using PD324_01.Models;

namespace PD324_01.Repositories
{
    public interface ICategoryRepository
    {
        Category? GetById(int id);
    }
}
