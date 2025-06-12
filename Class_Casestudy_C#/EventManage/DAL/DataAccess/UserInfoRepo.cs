using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.DataAccess
{
    public class UserInfoRepo : IUserInfoRepo<UserInfo>
    {
        public UserInfo RegisterUser(UserInfo user)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return user;
            }
        }
        public UserInfo UpdateUser(UserInfo user)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existingUser = dbContext.Users.Where(us => us.EmailId.Equals(user.EmailId)).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.Password = user.Password;
                    existingUser.UserName = user.UserName;
                    existingUser.Role = user.Role;
                    dbContext.SaveChanges();
                    return existingUser;
                }
                return null;
            }
        }

        public UserInfo DeleteUser(string emailId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var user = dbContext.Users.Where(us=> us.EmailId.Equals(emailId)).FirstOrDefault();
                if (user != null)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                    return user;
                }
                return null;
            }
        }
        public UserInfo ValidateUser(string emailId, string password)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                return dbContext.Users.FirstOrDefault(u => u.EmailId == emailId && u.Password == password);
            }
        }

        public UserInfo GetUserByEmail(string emailId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existingProduct = dbContext.Users.Where(us => us.EmailId.Equals(emailId)).FirstOrDefault();

                return existingProduct;
            }
        }

        public List<UserInfo> GetAllUsers()
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                return dbContext.Users.ToList();
            }
        }
    }
}
