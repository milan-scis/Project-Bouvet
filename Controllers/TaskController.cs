using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Task;

namespace BouvetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly string _errorMessage = "There was a problem with processing the request.";

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetTaskDto>>> Get()
        {
            try
            {
                return Ok(await _taskService.GetAllTasks());
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<GetTaskDto>> Get(int taskId)
        {
            try
            {
                return Ok(await _taskService.GetTaskById(taskId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<string>> Add(AddTaskDto newTask)
        {
            try
            {
                return Ok(await _taskService.AddTask(newTask));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<string>> Update(UpdateTaskDto updatedTask)
        {
            try
            {
                return Ok(await _taskService.UpdateTask(updatedTask));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpDelete("{taskId}")]
        public async Task<ActionResult<string>> Delete(int taskId)
        {
            try
            {
                return Ok(await _taskService.DeleteTaskById(taskId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }
    }
}
