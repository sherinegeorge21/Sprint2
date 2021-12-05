using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;

namespace WebApplication71.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _repository;
        private AppDbContext _context;

        public ProjectController(IProjectRepository repository,AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _context.GetAllProjects();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.GetProjectByID(id);
            if (data == null)
                return NotFound("no record found");
            return Ok(data);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Project project)
        {
            var data = _context.AddProject(project);
            _context.SaveChanges();
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + project.Id, data);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put(Project project)
        {
            bool f = _context.UpdateProject(project);
            _context.SaveChanges();
            var data = _context.GetAllProjects();
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
            _context.DeleteProject(id);
            _context.SaveChanges();

        }

    }
}
