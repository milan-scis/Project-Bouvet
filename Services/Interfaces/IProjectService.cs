using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using BouvetTask.Dtos.Project;

namespace BouvetTask.Services.Interfaces
{
    public interface IProjectService
    {
        Task<GetProjectDto> GetProjectById(int projectId);
        Task<List<GetProjectDto>> GetAllProjects();
        Task<string> AddProject(AddProjectDto newProject);
        Task<string> UpdateProject(UpdateProjectDto updatedProject);
        Task<string> DeleteProject(int projectId);
    }
}
