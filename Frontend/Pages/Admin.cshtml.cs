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

        [BindProperty]
        public Project NewProject { get; set; }

        public AdminModel(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _projectRepository.AddProjectAsync(NewProject);
            return RedirectToPage("/Index");
        }
    }
}
