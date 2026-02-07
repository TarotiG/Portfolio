namespace Frontend.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly ProjectRepository _projectRepository;
        private readonly TechnologyRepository _technologyRepository;
        private readonly CertificateService _certificateService;
        private readonly BestandService _bestandService;

        public List<Technology> Technologies { get; set; }

        [BindProperty]
        public Project NewProject { get; set; } = new();

        [BindProperty]
        public Certificate NewCertificate { get; set; } = new();

        [BindProperty]
        public Technology NewTechnology { get; set; } = new();

        [BindProperty]
        public List<Guid> SelectedTechnologyIds { get; set; } = new();

        public AdminModel(
            ProjectRepository projectRepository,
            CertificateService certificateService,
            BestandService bestandService,
            TechnologyRepository technologyRepository
            )
        {
            _projectRepository = projectRepository;
            _certificateService = certificateService;
            _bestandService = bestandService;
            _technologyRepository = technologyRepository;

            
        }
        public void OnGet()
        {
            Technologies = _technologyRepository.GetAllTechnologiesAsync().Result;
        }

        public async Task<IActionResult> OnPostProjectAsync()
        {
            if (SelectedTechnologyIds != null && SelectedTechnologyIds.Any())
            {
                foreach (Guid techId in SelectedTechnologyIds)
                {
                    Technology technology = _technologyRepository.GetTechnologyByIdAsync(techId).Result;
                    NewProject.Technologies.Add(technology);
                }
                
            }

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

        public async Task<IActionResult> OnPostTechnologyAsync()
        {
            await _technologyRepository.AddTechnologyAsync(NewTechnology);
            return RedirectToPage("Admin");
        }
    }
}
