using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using Microsoft.EntityFrameworkCore;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Project;
using AutoMapper;

namespace BouvetTask.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        
        public ProjectService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GetProjectDto> GetProjectById(int projectId)
        {
            using var context = new Bouvet_DBContext();
            var project = await context.Projects
                .Include(proj => proj.Epics)
                .ThenInclude(epic => epic.Tasks)
                .Where(proj => proj.ProjectId == projectId).FirstOrDefaultAsync();

            return _mapper.Map<GetProjectDto>(project);
        }

        public async Task<List<GetProjectDto>> GetAllProjects()
        {
            using var context = new Bouvet_DBContext();
            var projects = await context.Projects
                .Include(proj => proj.Epics)
                .ThenInclude(epic => epic.Tasks)
                .Select(proj => _mapper.Map<GetProjectDto>(proj))
                .ToListAsync();

            return projects;
        }

        public async Task<string> AddProject(AddProjectDto newProject)
        {
            using var context = new Bouvet_DBContext();
            var mappedNewProject = _mapper.Map<Project>(newProject);
            await context.Projects.AddAsync(mappedNewProject);
            await context.SaveChangesAsync();

            return "New project added";
        }

        public async Task<string> UpdateProject(UpdateProjectDto updatedProject)
        {
            using var context = new Bouvet_DBContext();
            var projectId = updatedProject.ProjectId;
            Project project = await context.Projects
                .Where(p => p.ProjectId == projectId)
                .FirstOrDefaultAsync();

            if (project == null)
            {
                return "There is no project with id " + projectId;
            }

            var mappedUpdatedProject = _mapper.Map<Project>(updatedProject);
            context.ChangeTracker.Clear();
            context.Projects.Update(mappedUpdatedProject);
            await context.SaveChangesAsync();

            return "Project updated";
        }

        public async Task<string> DeleteProject(int projectId)
        {
            using var context = new Bouvet_DBContext();
            Project project = await context.Projects
                .Where(p => p.ProjectId == projectId)
                .FirstOrDefaultAsync();

            if (project == null)
            {
                return "There is no project with id " + projectId;
            }

            context.Projects.Remove(project);
            await context.SaveChangesAsync();

            return "Project deleted";
        }
    }
}
