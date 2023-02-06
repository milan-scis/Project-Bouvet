using AutoMapper;
using BouvetTask.Models;
using BouvetTask.Dtos.Project;
using BouvetTask.Dtos.Epic;
using BouvetTask.Dtos.Task;
using Task = BouvetTask.Models.Task;

namespace BouvetTask.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
            
            CreateMap<Epic, GetEpicDto>();
            CreateMap<AddEpicDto, Epic>();
            CreateMap<UpdateEpicDto, Epic>();
            
            CreateMap<Task, GetTaskDto>();
            CreateMap<AddTaskDto, Task>();
            CreateMap<UpdateTaskDto, Task>();
        }
    }
}
