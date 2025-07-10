using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : Controller
    {
        private readonly ILogger<CertificateController> _logger;
        private readonly CertificateRepository _certificateRepository;

        public CertificateController(ILogger<CertificateController> logger, CertificateRepository certificateRepository)
        {
            _logger = logger;
            _certificateRepository = certificateRepository;
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
    }
}
