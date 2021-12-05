using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
   public interface ITaskRepository
    {
        List<Task> GetAllTasks();
        Task GetTaskByID(int id);
        Task AddTask(Task task);
        void DeleteTask(int id);
        bool UpdateTask(Task task);
    }
}
