using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;
using HighwayTransportation.Providers;
using Microsoft.OpenApi.Any;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProjectController : ControllerBase
    {

        private readonly ProjectProvider _projectProvider;

        public ProjectController(ProjectProvider projectProvider)
        {
            _projectProvider = projectProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<GetProjectListDto>>> GetProjects()
        {
            var projects = await _projectProvider.GetProjects();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(CreateProjectDto project)
        {
            var createdProject = await _projectProvider.CreateProject(project);
            return CreatedAtAction(nameof(GetProjects), new { id = createdProject.Id }, createdProject);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProjectDetailDto>> GetProject(int id)
        {
            var project = await _projectProvider.GetProjectDetail(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDto project)
        {
            var projectEntity = await _projectProvider.UpdateProject(id, project);
            return Ok(projectEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectProvider.DeleteProject(id);
            return Ok();
        }
    }
}
