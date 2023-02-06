using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using Task = BouvetTask.Models.Task;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Task;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BouvetTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GetTaskDto> GetTaskById(int taskId)
        {
            using var context = new Bouvet_DBContext();
            var task = await context.Tasks
                .Where(t => t.TaskId == taskId)
                .FirstOrDefaultAsync();

            return _mapper.Map<GetTaskDto>(task);
        }

        public async Task<List<GetTaskDto>> GetAllTasks()
        {
            using var context = new Bouvet_DBContext();

            return await context.Tasks
                .Select(task => _mapper.Map<GetTaskDto>(task))
                .ToListAsync();
        }

        public async Task<string> AddTask(AddTaskDto newTask)
        {
            using var context = new Bouvet_DBContext();
            var mappedNewTask = _mapper.Map<Task>(newTask);
            await context.Tasks.AddAsync(mappedNewTask);
            await context.SaveChangesAsync();

            return "New task added";
        }

        public async Task<string> UpdateTask(UpdateTaskDto updatedTask)
        {
            using var context = new Bouvet_DBContext();
            var taskId = updatedTask.TaskId;
            Task task = await context.Tasks
                .Where(t => t.TaskId == taskId)
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return "There is no task with id " + taskId;
            }

            var mappedUpdatedTask = _mapper.Map<Task>(updatedTask);
            context.ChangeTracker.Clear();
            context.Tasks.Update(mappedUpdatedTask);
            await context.SaveChangesAsync();

            return "Task updated";
        }

        public async Task<string> DeleteTaskById(int taskId)
        {
            using var context = new Bouvet_DBContext();
            Task task = await context.Tasks
                .Where(t => t.TaskId == taskId)
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return "There is no task with id " + taskId;
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return "Task deleted";
        }
    }
}
