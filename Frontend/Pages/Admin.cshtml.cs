using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Frontend.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly ProjectRepository _projectRepository;
        private readonly CertificateService _certificateService;
        private readonly BestandService _bestandService;

        [BindProperty]
        public Project NewProject { get; set; } = new();

        [BindProperty]
        public Certificate NewCertificate { get; set; } = new();

        public AdminModel(ProjectRepository projectRepository, CertificateService certificateService, BestandService bestandService)
        {
            _projectRepository = projectRepository;
            _certificateService = certificateService;
            _bestandService = bestandService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostProjectAsync()
        {
            NewProject.StartDate = DateTime.SpecifyKind(NewProject.StartDate, DateTimeKind.Utc);

            if (NewProject.EndDate == null)
            {
                NewProject.EndDate = DateTime.UtcNow;
            }
            else
            {
                NewProject.EndDate = DateTime.SpecifyKind(NewProject.EndDate.Value, DateTimeKind.Utc);
            }

            await _projectRepository.AddProjectAsync(NewProject);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostCertificateAsync(IFormFile file)
        {
            NewCertificate.IssueDate = DateTime.SpecifyKind(NewCertificate.IssueDate, DateTimeKind.Utc);
            NewCertificate.CertificateFile = _bestandService.ProcessFileFromRequest(file).Result;

            await _certificateService.AddCertificate(NewCertificate);

            return RedirectToPage("Index");
        }
    }
}
