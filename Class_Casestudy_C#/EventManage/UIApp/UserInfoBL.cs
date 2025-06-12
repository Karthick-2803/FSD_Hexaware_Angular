using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccess;
using DAL.Models;

namespace UIApp
{
    public class UserInfoBL
    {
        private readonly IUserInfoRepo<UserInfo> _userRepo;

        public UserInfoBL(IUserInfoRepo<UserInfo> userRepo)
        {
            this._userRepo = userRepo;
        }

        public bool RegisterUser(UserInfo user)
        {
            var newUser = _userRepo.RegisterUser(user);
            if (newUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateUser(UserInfo user)
        {
            var updatedUser = _userRepo.UpdateUser(user);
            if (updatedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(string emailId)
        {
            var deletedUser = _userRepo.DeleteUser(emailId);
            if (deletedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserInfo ValidateUser(string emailId, string password)
        {
            return _userRepo.ValidateUser(emailId, password);
        }

        public UserInfo GetUserByEmail(string emailId)
        {
            return _userRepo.GetUserByEmail(emailId);
        }

        public List<UserInfo> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
    }
}

