using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Dtos.Task;
using Task = BouvetTask.Models.Task;

namespace BouvetTask.Services.Interfaces
{
    public interface ITaskService
    {
        Task<GetTaskDto> GetTaskById(int taskId);
        Task<List<GetTaskDto>> GetAllTasks();
        Task<string> AddTask(AddTaskDto newTask);
        Task<string> UpdateTask(UpdateTaskDto updatedTask);
        Task<string> DeleteTaskById(int taskId);

    }
}
