using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Repositories
{
    public class CertificateRepository
    {
        private readonly AppDbContext _context;

        public CertificateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Certificate>> GetAllCertificatesAsync()
        {
            return await _context.Certificates.ToListAsync();
        }

        public async Task<Certificate> GetCertificateByIdAsync(Guid id)
        {
            return await _context.Certificates.FindAsync(id);
        }

        public async Task AddCertificateAsync(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCertificateAsync(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCertificateAsync(Guid id)
        {
            var certificate = await GetCertificateByIdAsync(id);
            if (certificate != null)
            {
                _context.Certificates.Remove(certificate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
