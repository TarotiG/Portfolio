namespace Backend.Services
{
    public class PDFService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PDFService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] GetPDF(string fileName)
        {
            string filePath;
            filePath = Path.Combine("wwwroot", "pdf-files", fileName);

            if (!File.Exists(filePath))
            {
                throw new Exception($"File '{fileName}' does not exist.");
            }
            
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return fileBytes;
        }
    }
}
