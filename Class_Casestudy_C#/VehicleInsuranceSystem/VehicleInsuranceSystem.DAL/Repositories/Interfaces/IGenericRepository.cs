using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        //Task SaveAsync();
        Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

    }
}
