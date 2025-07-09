using Microsoft.AspNetCore.Mvc.RazorPages;
using Backend.Models;
using Backend.Persistence.Repositories;

namespace DevPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProjectRepository _projectRepository;

        public List<Project> Projecten { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProjectRepository projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        public void OnGet()
        {
            Projecten = _projectRepository.GetAllProjectsAsync().Result;

            //Projecten = new List<Project>
            //{
            //    new Project { Name="Robot Framework", Description="Keyword-based test framework."},
            //    new Project { Name="Selenium C#", Description="Code-based test framework dat gebruik maakt van Webdrivers."},
            //    new Project { Name="Playwright C#", Description="Code-based test framework dat wordt uitgevoerd met gebruik van de devtools."},
            //    new Project { Name="Selenium Python", Description="Code-based test framework dat wordt uitgevoerd met gebruik van de devtools."},
            //    new Project { Name="Robot Framework - Python", Description="Keyword-based test framework dat code-technische oplossingen bevat."},
            //    new Project { Name="Cypress", Description="Code-based test framework dat wordt uitgevoerd met gebruik van de devtools."}
            //};

        }
    }
}
