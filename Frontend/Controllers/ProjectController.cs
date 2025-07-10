using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ProjectRepository _projectRepository;

        public ProjectController(ILogger<ProjectController> logger, ProjectRepository projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                List<Project> projects = await _projectRepository.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving projects.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
