using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Backend.Models;

namespace Backend.Services
{
    public class BestandService
    {
        private readonly BestandRepository _bestandRepository;

        public BestandService(BestandRepository bestandRepository)
        {
            _bestandRepository = bestandRepository;
        }

        #region Db acties
        public async Task<List<Bestand>> GetAllBestandenAsync()
        {
            return await _bestandRepository.GetAllBestandenAsync();
        }

        public async Task<Bestand?> GetBestandByIdAsync(Guid id)
        {
            return await _bestandRepository.GetBestandByIdAsync(id);
        }

        public async Task AddBestandAsync(Bestand bestand)
        {
            if (bestand == null)
            {
                throw new ArgumentNullException(nameof(bestand), "Bestand cannot be null");
            }
            await _bestandRepository.AddBestandAsync(bestand);
        }
        #endregion

        #region Methodes

        public async Task<Bestand> ProcessFileFromRequest(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty", nameof(file));
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            return new Bestand
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileType = file.ContentType,
                FileData = memoryStream.ToArray()
            };
        }
        #endregion
    }
}
