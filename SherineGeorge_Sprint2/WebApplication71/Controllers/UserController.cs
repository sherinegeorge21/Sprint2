using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication71.Controllers
{
    public class UserController : Controller
    {
        
        private readonly IUserRepository _repository;

        private AppDbContext _context;
        private DbSet<User> users;

        public UserController(IUserRepository repository,AppDbContext context)
        {
            _repository = repository;
            _context = context;
            users = _context.Users;
    }

        
        
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
           var data = _context.GetAllUsers();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.GetUserByID(id);
            //if (data == null)
            //    return NotFound("no record found");
            //return Ok(data);
            ////users = _context.Users;
            //var response = users.Select(u => new
            //{
            //    Id = u.Id,
            //    FirstName = u.FirstName,
            //    lastName = u.LastName,
            //    Email = u.Email,
            //    Password = u.Password
            //});
           // var data=users.FirstOrDefault(user => user.Id == id);
            if (data == null)
                return NotFound("no record found");
            return Ok(data);

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(User user)
        {
           var data = _context.AddUser(user);
           
            //int count=users.Count();
            //user.Id = ++count;
            //users.Add(user);
            _context.SaveChanges();
         
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + user.Id, data);


        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put(User user)
        {
             bool f=_context.UpdateUser(user);
             ////var users = _context.Users;
            //User index= users.Find(user.Id);
            //if (index != null)
            //{
            //    users.Remove(index);
            //    users.Add(user);
               _context.SaveChanges();
            //    return Ok(user);
            //}
            //else
            //{
            //    return NotFound("no record found");
            //}
            if (f == true)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("no record found");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public void Delete(int id)
        {
            _context.DeleteUser(id);
            ////var users = _context.Users;
            //User user = users.FirstOrDefault(user => user.Id == id);
            //users.Remove(user);
            _context.SaveChanges();

        }
    }
}
