using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public class ProjectMockService:IProjectRepository
    {


        private  DbSet<Project> projects;
        private int count = 3;

        public ProjectMockService()
        {
            //projects = new List<Project>()
            //{

            //    new Project() { Id = 1, Name = "Mark", Detail = "Angular App", CreatedOn=new DateTime(2021,9,10)},
            //    new Project() { Id = 2, Name = "Hegde", Detail = "ASP .Net Core Project", CreatedOn=new DateTime(2021,6,17)},
            //    new Project() { Id = 3, Name = "Maria", Detail = "HTML Project", CreatedOn=new DateTime(2020,5,12)}

            //};
        }
        public Project AddProject(Project project)
        {
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

            //int index = projects.FindIndex(c => c.Id == project.Id);
            //if (index == -1)
            //{
            //    return false;

            //}
            //projects.RemoveAt(index);
            //projects.Add(project);
            return true;
        }

    }
}
