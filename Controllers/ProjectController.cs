using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Project;

namespace BouvetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly string _errorMessage = "There was a problem with processing the request.";

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetProjectDto>>> Get()
        {
            try
            {
                return Ok(await _projectService.GetAllProjects());
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<GetProjectDto>> Get(int projectId)
        {
            try
            {
                return Ok(await _projectService.GetProjectById(projectId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<string>> Add(AddProjectDto newProject)
        {
            try
            {
                return Ok(await _projectService.AddProject(newProject));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<string>> Update(UpdateProjectDto updatedProject)
        {
            //try
            //{
            return Ok(await _projectService.UpdateProject(updatedProject));
            //}
            //catch
            //{
            //    return BadRequest(_errorMessage);
            //}
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<string>> Delete(int projectId)
        {
            try
            {
                return Ok(await _projectService.DeleteProject(projectId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }
    }
}
