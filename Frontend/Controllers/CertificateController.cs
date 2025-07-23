using Backend.Models;
using Backend.Persistence.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly ILogger<CertificateController> _logger;
        private readonly CertificateRepository _certificateRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PDFService _pdfService;

        public CertificateController(
            ILogger<CertificateController> logger,
            CertificateRepository certificateRepository,
            IWebHostEnvironment webHostEnvironment,
            PDFService pdfService
            )
        {
            _logger = logger;
            _certificateRepository = certificateRepository;
            _webHostEnvironment = webHostEnvironment;
            _pdfService = pdfService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            try
            {
                List<Certificate> certificates = await _certificateRepository.GetAllCertificatesAsync();
                return Ok(certificates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving certificates.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPdf(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name cannot be null or empty.");
            }

            try
            {
                var file = _pdfService.GetPDF(fileName);
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the PDF file.");
                return NotFound($"File '{fileName}' not found.");
            }

        }
    }
}
