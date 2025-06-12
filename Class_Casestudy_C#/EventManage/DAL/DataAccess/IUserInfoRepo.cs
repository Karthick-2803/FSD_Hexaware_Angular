using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IUserInfoRepo<T>
    {
        T RegisterUser(T user);
        T UpdateUser(T user);
        T DeleteUser(string emailId);
        T ValidateUser(string emailId, string password);
        T GetUserByEmail(string emailId);
        List<T> GetAllUsers();
    }
}
