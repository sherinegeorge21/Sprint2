using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;

namespace WebApplication71.Models
{
    public class UserMockService : IUserRepository
    {

        //private static List<User> users;
        private AppDbContext _context;
        private DbSet<User> users;
       
        

        public UserMockService()
        {
            //_context = context;
           
           // users = _context.Users;
           
            //users = new List<User>()
            //{

            //    new User() { Id = 1, FirstName = "Mark", LastName = "Paul", Email = "mark.paul@gmail.com", Password = "whatsapp123" },
            //    new User() { Id = 2, FirstName = "John", LastName = "Lenon", Email = "john.lenon@gmail.com", Password = "user123" },
            //    new User() { Id = 3, FirstName = "Sherine", LastName = "George", Email = "sherry.george@gmail.com", Password = "myname123" }

            //};
        }
        public User AddUser(User user)
        {
            int count = users.Count();
            user.Id = ++count;
            users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            User user = GetUserByID(id);
            users.Remove(user);
            _context.SaveChanges();
        }

        public DbSet<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserByID(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public bool UpdateUser(User user)
        {

            User index = users.Find(user.Id);
            if (index != null)
            {
                users.Remove(index);
                users.Add(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
       
        }
    }
}
