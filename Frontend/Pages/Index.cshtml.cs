using Microsoft.AspNetCore.Mvc.RazorPages;
using Backend.Models;
using Backend.Persistence.Repositories;

namespace DevPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProjectRepository _projectRepository;
        private readonly CertificateRepository _certificateRepository;

        public string AboutMeText { get; set; }
        public List<Project> Projecten { get; set; }
        public List<Certificate> Certificaten { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProjectRepository projectRepository, CertificateRepository certificateRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _certificateRepository = certificateRepository;
        }

        public void OnGet()
        {
            AboutMeText = "Ik ben een test-automation engineer en developer met 5 jaar ervaring in het bouwen van betrouwbare, schaalbare en onderhoudbare oplossingen van testen binnen systemen. Ik werk graag met technologieën zoals C#, Java, Python, Selenium, Robot Framework, Playwright en CI/CD pipelines.";
            
            // DB Acties
            Projecten = _projectRepository.GetAllProjectsAsync().Result;
            Certificaten = _certificateRepository.GetAllCertificatesAsync().Result;

        }
    }
}
