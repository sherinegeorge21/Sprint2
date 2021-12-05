using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication71.Models
{
    public class AppDbContext:DbContext,IUserRepository,IProjectRepository
    {

        private static AppDbContext _context;
        private DbSet<User> users;
        private DbSet<Project> projects;
        private DbSet<Task> tasks;

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            
            users = Users;
            projects = Projects;
            tasks = Tasks;

        }

        public static void AddTestData(AppDbContext context)
        {
            _context = context;
            var user = new User
            {
                Id = 1,
                FirstName = "Mark",
                LastName = "Paul",
                Email = "mark.paul@gmail.com",
                Password = "whatsapp123"
            };

            _context.Users.Add(user);

            var task = new Task
            {
                Id = 1,
                ProjectID = 3,
                Status = 2,
                AssignedToUserID = 2,
                Detail = "Angular App",
                CreatedOn = new DateTime(2021, 9, 10)
            };

            _context.Tasks.Add(task);

            var project = new Project
            {
                Id = 1,
                Name = "Mark",
                Detail = "Angular App",
                CreatedOn = new DateTime(2021, 9, 10)
            };

            _context.Projects.Add(project);

            _context.SaveChanges();
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


        public Project AddProject(Project project)
        {
            int count = projects.Count();
            project.Id = ++count;
            projects.Add(project);
            return project;
        }

        public void DeleteProject(int id)
        {
            Project project = GetProjectByID(id);
            projects.Remove(project);
        }

        public DbSet<Project> GetAllProjects()
        {
            return projects;
        }

        public Project GetProjectByID(int id)
        {
            return projects.FirstOrDefault(project => project.Id == id);
        }

        public bool UpdateProject(Project project)
        {

            Project index = projects.Find(project.Id);
   
            if (index != null)
            {
                projects.Remove(index);
                projects.Add(project);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
         
        }


        public Task AddTask(Task task)
        {
            int count = tasks.Count();
            task.Id = ++count;
            tasks.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            Task task = GetTaskByID(id);
            tasks.Remove(task);
        }

        public DbSet<Task> GetAllTasks()
        {
            return tasks;
        }

        public Task GetTaskByID(int id)
        {
            return tasks.FirstOrDefault(task => task.Id == id);
        }

        public bool UpdateTask(Task task)
        {

            Task index = tasks.Find(task.Id);
            if (index != null)
            {
                tasks.Remove(index);
                tasks.Add(task);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
