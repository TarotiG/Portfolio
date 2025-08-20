

using Backend.Models;
using Backend.Persistence.Repositories;

namespace Backend.Services
{
    public class CertificateService
    {
        private readonly CertificateRepository _certificateRepository;

        public CertificateService(CertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<List<Certificate>> GetAllCertificates()
        {
            return await _certificateRepository.GetAllCertificatesAsync();
        }

        public async Task AddCertificate(Certificate certificate)
        {
            await _certificateRepository.AddCertificateAsync(certificate);
        }
    }
}
