using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Frontend.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly ProjectRepository _projectRepository;
        private readonly CertificateRepository _certificateRepository;

        [BindProperty]
        public Project NewProject { get; set; } = new();

        [BindProperty]
        public Certificate NewCertificate { get; set; } = new();

        public AdminModel(ProjectRepository projectRepository, CertificateRepository certificateRepository)
        {
            _projectRepository = projectRepository;
            _certificateRepository = certificateRepository;
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

        public async Task<IActionResult> OnPostCertificateAsync()
        {
            NewCertificate.IssueDate = DateTime.SpecifyKind(NewCertificate.IssueDate, DateTimeKind.Utc);
            await _certificateRepository.AddCertificateAsync(NewCertificate);
            return RedirectToPage("Index");
        }
    }
}
