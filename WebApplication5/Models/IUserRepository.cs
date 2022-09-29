using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        User AddUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
    }
}
