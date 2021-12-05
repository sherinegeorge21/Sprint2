using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public class TaskMockService :ITaskRepository
    {

        private static List<Task> tasks;
        private int count = 3;

        public TaskMockService()
        {
            //tasks = new List<Task>()
            //{

            //    new Task() { Id = 1, ProjectID = 3,Status=2,AssignedToUserID=2, Detail = "Angular App", CreatedOn=new DateTime(2021,9,10)},
            //    new Task() { Id = 2, ProjectID = 4,Status=1,AssignedToUserID=1, Detail = "Android App", CreatedOn=new DateTime(2021,4,8)},
            //    new Task() { Id = 3, ProjectID = 5,Status=3,AssignedToUserID=3, Detail = "Asp.net Web App", CreatedOn=new DateTime(2020,3,3)}

            //};
        }
        public Task AddTask(Task task)
        {
            task.Id = ++count;
            tasks.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            Task task = GetTaskByID(id);
            tasks.Remove(task);
        }

        public List<Task> GetAllTasks()
        {
            return tasks;
        }

        public Task GetTaskByID(int id)
        {
            return tasks.FirstOrDefault(task => task.Id == id);
        }

        public bool UpdateTask(Task task)
        {

            int index = tasks.FindIndex(c => c.Id == task.Id);
            if (index == -1)
            {
                return false;

            }
            tasks.RemoveAt(index);
            tasks.Add(task);
            return true;
        }

    }
}
