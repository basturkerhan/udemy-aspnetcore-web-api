using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.WebApi.Controllers.Data;

namespace Udemy.WebApi.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
    }
}
