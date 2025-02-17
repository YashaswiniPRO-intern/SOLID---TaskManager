using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Models.Models;
using TaskManager.Repositories;
using TaskManager.Repositories.Entities;
using TaskManager.Repositories.Interface;
using TaskManager.Services.Interface;

namespace TaskManager.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepo, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _mapper = mapper;
        }
        public async Task<List<TaskModel>> GetAll()
        {
            List<TaskEntity> te = await _taskRepo.GetAll();
            return _mapper.Map<List<TaskModel>>(te);
        }
        public async Task<TaskModel> GetById(int TaskId)
        {
            var task = await _taskRepo.GetById(TaskId);
            return _mapper.Map<TaskModel>(task);
        }
        public async Task<TaskModel> AddTask(TaskModel tm)
        {
            var t = _mapper.Map<TaskEntity>(tm);
            var newTask = await _taskRepo.AddTask(t);
            return _mapper.Map<TaskModel>(newTask);
        }
        public async Task<TaskModel> UpdateTask(int TaskId, TaskModel tm)
        {
            var existingTask = await _taskRepo.GetById(TaskId);
            if (existingTask == null)
                return null;
            _mapper.Map(tm, existingTask);
            var updatedTask = await _taskRepo.UpdateTask(TaskId,existingTask);
            return _mapper.Map<TaskModel>(updatedTask);


        }
        public async Task<bool> DeleteTask(int TaskId)
        {
            return await _taskRepo.DeleteTask(TaskId);
        }
        public async Task<TaskModel> UpdateTaskPriority(int  TaskId, int prio)
        {
            var existingTask = await _taskRepo.GetById(TaskId);
            if (existingTask == null)
                return null;
            existingTask.Priority = prio;
            var updatedTask = await _taskRepo.UpdateTask(TaskId,existingTask);
            return _mapper.Map<TaskModel>(updatedTask);
        }
        public async Task<List<TaskModel>> GetTasksByUserId(int UserId)
        {
            var tasks = await _taskRepo.GetTasksByUserId(UserId);
            return _mapper.Map<List<TaskModel>>(tasks);
        }
        
    }
}
