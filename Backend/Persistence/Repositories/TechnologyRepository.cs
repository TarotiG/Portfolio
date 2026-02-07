using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Repositories
{
    public class TechnologyRepository
    {
        private readonly AppDbContext _context;

        public TechnologyRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddTechnologyAsync(Technology technology)
        {
            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Technology>> GetAllTechnologiesAsync()
        {
            return await _context.Technologies.ToListAsync();
        }

        public async Task<Technology> GetTechnologyByIdAsync(Guid techId)
        {
            return await _context.Technologies.FindAsync(techId);
        }
    }
}
