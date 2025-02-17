using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.Models;
using TaskManager.Services.Interface;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<TaskModel> taskModels = await _taskService.GetAll();   
            return Ok(taskModels);
        }
        [HttpGet("{TaskId}")]
        public async Task<IActionResult> GetById(int TaskId)
        {
            var user = await _taskService.GetById(TaskId); //can write if(user==null) return NotFound()
            return Ok(user);
        }
        //for post we pass usermodel as a parameter 
        [HttpPost("AddTask")]
        public async Task<IActionResult> CreateTask([FromBody] TaskModel tm)
        {
            var newTask = await _taskService.AddTask(tm);
            return Ok(newTask);
        }
        [HttpDelete("DeleteTask/{TaskId}")]
        public async Task<IActionResult> DeleteTask(int TaskId)
        {
            var res = await _taskService.DeleteTask(TaskId);
            if (res == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("GetTasksByUserId/{UserId}")]
        public async Task<IActionResult> GetTasksByUserId(int UserId)
        {
            var tasks = await _taskService.GetTasksByUserId(UserId);
            return Ok(tasks);
        }

        
    }
}
