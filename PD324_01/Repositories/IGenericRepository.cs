namespace PD324_01.Repositories
{
    public interface IGenericRepository<TModel>
        where TModel : class
    {
        Task<bool> CreateAsync(TModel model);
        Task<bool> RemoveAsync(TModel model);
        Task<bool> UpdateAsync(TModel model);
        IQueryable<TModel> GetAll();
    }
}
