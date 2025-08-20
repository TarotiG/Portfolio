using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Repositories
{
    public class BestandRepository
    {
        private readonly AppDbContext _context;

        public BestandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bestand>> GetAllBestandenAsync()
        {
            return await _context.Bestanden.ToListAsync();
        }

        public async Task<Bestand?> GetBestandByIdAsync(Guid id)
        {
            return await _context.Bestanden.FindAsync(id);
        }

        public async Task AddBestandAsync(Bestand bestand)
        {
            _context.Bestanden.Add(bestand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBestandAsync(Bestand bestand)
        {
            _context.Bestanden.Update(bestand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBestandAsync(Guid id)
        {
            var bestand = await GetBestandByIdAsync(id);
            if (bestand != null)
            {
                _context.Bestanden.Remove(bestand);
                await _context.SaveChangesAsync();
            }
        }
    }
}
