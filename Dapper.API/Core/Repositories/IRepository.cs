namespace Dapper.API.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
    }
}
