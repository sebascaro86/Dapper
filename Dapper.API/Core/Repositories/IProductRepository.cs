using Dapper.API.Core.Entities;

namespace Dapper.API.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetById(int id);
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int id);
    }
}
