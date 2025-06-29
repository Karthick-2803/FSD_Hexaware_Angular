using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User> RegisterUserAsync(User user);
        Task<User?> AuthenticateUserAsync(string email, string password);
        Task<User> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(User user);
    }
}
