using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Web.DAL.Models;

namespace Class_Web.BLL.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventDetails>> GetAllAsync();
        Task<EventDetails?> GetByIdAsync(int id);
        Task AddAsync(EventDetails ev);
        Task UpdateAsync(EventDetails ev);
        Task DeleteAsync(int id);
    }
}
