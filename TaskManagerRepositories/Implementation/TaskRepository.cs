using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Repositories.Entities;
using TaskManager.Repositories.Interface;

namespace TaskManager.Repositories.Implementation
{
    public class TaskRepository:ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TaskEntity>> GetAll()
        {
            return await _dbContext.Tasks.ToListAsync();
        }
        public async Task<TaskEntity> GetById(int TaskId)
        {
            var task = await _dbContext.Tasks.FindAsync(TaskId);  
            return task;
        }
        public async Task<TaskEntity> AddTask(TaskEntity te)
        {
            _dbContext.Tasks.Add(te);
            await _dbContext.SaveChangesAsync();
            return te;

        }
        public async Task<TaskEntity> UpdateTask(int TaskId, TaskEntity te)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(TaskId);//get the id of which task you want to update
            if (existingTask == null)
                return null;
            //make updates to all columns
            existingTask.TaskName = te.TaskName;
            await _dbContext.SaveChangesAsync();//save the changes
            return existingTask;//returning only the updated task
        }
        public async Task<bool> DeleteTask(int TaskId)
        {
            var task = await _dbContext.Tasks.FindAsync(TaskId);
            if (task == null)
                return false;
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<TaskEntity>> GetTasksByUserId(int userId)
        {
            return await _dbContext.Tasks.Where(t => t.UserId == userId).ToListAsync();
        }
        

    }
}
