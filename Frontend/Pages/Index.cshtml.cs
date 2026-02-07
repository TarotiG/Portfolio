using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DevPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProjectRepository _projectRepository;
        private readonly CertificateService _certificateService;

        public string AboutMeText { get; set; }
        public List<Project> Projecten { get; set; }
        public List<Certificate> Certificaten { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProjectRepository projectRepository, CertificateService certificateService)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _certificateService = certificateService;
        }

        public async void OnGetAsync()
        {
            AboutMeText = "Ik ben een test-automation engineer en developer met 6 jaar ervaring in het ontwerpen en bouwen van betrouwbare, schaalbare en onderhoudbare testoplossingen binnen complexe systemen.\n\nIk ben TMAP-gecertificeerd en werk methodologisch sterk, waarbij ik continu vooruitkijk naar moderne en effectieve teststrategieën.\nMijn expertise ligt zowel in testautomatisering als development, met ervaring in technologieën zoals C#, Java, Python en JavaScript/TypeScript, en frameworks zoals Selenium, Robot Framework en Playwright. Daarnaast heb ik ruime ervaring met API testing, waaronder REST- en GraphQL-services, waarbij ik tools zoals Postman en Bruno inzet voor zowel geautomatiseerde als exploratieve tests.\n\nIk werk graag in omgevingen met CI/CD-pipelines en draag actief bij aan kwaliteit binnen het volledige ontwikkelproces. Daarbij ben ik sterk technisch vooruitstrevend en experimenteer ik actief met AI-driven testing en het toepassen van Generative AI binnen zowel development als testprocessen, om efficiëntie, testdekking en kwaliteit verder te verhogen.";

            // DB Acties
            Projecten = _projectRepository.GetAllProjectsAsync().Result;
            Certificaten = await _certificateService.GetAllCertificates();
        }
    }
}
