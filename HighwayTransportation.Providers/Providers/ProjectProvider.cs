using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;


namespace HighwayTransportation.Providers
{
    public class ProjectProvider : ProviderBase<ProjectService, Project>
    {
        IMapper _mapper;
        ProjectService _projectService;

        public ProjectProvider(ProjectService projectService, IMapper mapper) : base(projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        public async Task<List<GetProjectListDto>> GetProjects()
        {
            //IsDeleted == false
            var projects = await _projectService.GetAllAsync();
            return _mapper.Map<List<GetProjectListDto>>(projects.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Project> CreateProject(CreateProjectDto project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            await _projectService.AddAsync(projectEntity);
            return projectEntity;
            
        }

        public async Task<GetProjectDetailDto> GetProjectDetail(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null || project.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetProjectDetailDto>(project);
        }

        public async Task<GetProjectDetailDto> UpdateProject(int id, UpdateProjectDto project)
        {
            var projectEntity = _projectService.GetByIdAsync(id).Result;
            projectEntity.Name = project.Name;
            projectEntity.Description = project.Description;
            projectEntity.StartDate = project.StartDate;
            projectEntity.EndDate = project.EndDate;
            await _projectService.UpdateAsync(projectEntity);
            return _mapper.Map<GetProjectDetailDto>(projectEntity);
        }

        public async Task DeleteProject(int id)
        {
            var projectEntity = _projectService.GetByIdAsync(id).Result;
            projectEntity.IsDeleted = true;
            await _projectService.UpdateAsync(projectEntity);
        }
    }
}