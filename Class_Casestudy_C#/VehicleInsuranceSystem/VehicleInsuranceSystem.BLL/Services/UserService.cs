using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceSystem.DAL.Data;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var users = await _userRepository.GetAllAsync();
            return users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password)
        {
            var users = await _userRepository.GetAllAsync();
            return users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }
        public async Task<User?> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }

    }



}
