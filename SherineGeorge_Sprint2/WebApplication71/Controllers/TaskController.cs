using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;
using Task = WebApplication71.Models.Task;

namespace WebApplication71.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;
        private AppDbContext _context;

        public TaskController(ITaskRepository repository,AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _context.GetAllTasks();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.GetTaskByID(id);
            if (data == null)
                return NotFound("no record found");
            return Ok(data);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Task task)
        {
            var data = _context.AddTask(task);
            _context.SaveChanges();
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + task.Id, data);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put(Task task)
        {
            bool f = _context.UpdateTask(task);
            _context.SaveChanges();
            var data = _context.GetAllTasks();
            if (f == true)
            {
                return Ok(data);
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
            _context.DeleteTask(id);
            _context.SaveChanges();

        }

    }
}
