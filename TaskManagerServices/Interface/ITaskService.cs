using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Models;

namespace TaskManager.Services.Interface
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(int TaskId);
        Task<TaskModel> AddTask(TaskModel tm);
        Task<TaskModel> UpdateTask(int TaskId, TaskModel task);
        Task<bool> DeleteTask(int TaskId);
        Task<List<TaskModel>> GetTasksByUserId(int UserId);
    }
}
