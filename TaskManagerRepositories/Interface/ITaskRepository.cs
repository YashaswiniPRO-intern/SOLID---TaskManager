using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Repositories.Entities;

namespace TaskManager.Repositories.Interface
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAll();
        Task<TaskEntity> GetById(int TaskId);
        Task<TaskEntity> AddTask(TaskEntity task);
        Task<TaskEntity> UpdateTask(int TaskId, TaskEntity te);
        Task<bool> DeleteTask(int TaskId);
        Task<List<TaskEntity>> GetTasksByUserId(int userId);
    }
}
