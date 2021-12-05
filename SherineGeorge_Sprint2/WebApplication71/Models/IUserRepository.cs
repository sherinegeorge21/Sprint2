using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public interface IUserRepository
    {
        DbSet<User> GetAllUsers();
        User GetUserByID(int id);
        User AddUser(User user);
        void DeleteUser(int id);
        bool UpdateUser(User user);
    }
}
