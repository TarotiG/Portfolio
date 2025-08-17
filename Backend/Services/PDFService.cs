using PdfiumViewer;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace Backend.Services
{
    public class PDFService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private string BasePath => _webHostEnvironment.IsProduction() ? Path.Combine(_webHostEnvironment.WebRootPath, "pdf-files") : Path.Combine("wwwroot", "pdf-files");

        public PDFService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] GetPDF(string fileName)
        {
            string filePath = Path.Combine(BasePath, fileName);

            if (!File.Exists(filePath))
            {
                throw new Exception($"File '{fileName}' does not exist.");
            }
            
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return fileBytes;
        }

        //public Image ConvertPdftoJpg(string fileName)
        //{
        //    string filePath = Path.Combine(BasePath, fileName);
        //    string outputPath = Path.Combine(filePath, "output-jpg");

        //    if (!Directory.Exists(outputPath))
        //    {
        //        Directory.CreateDirectory(outputPath);
        //    }

        //    try
        //    {
        //        using (var document = PdfDocument.Load(pdfPath))
        //        {
        //            int dpi = 96;
        //            using (var image = document.Render(1, dpi, dpi, true))
        //            {
        //                string jpgPath = Path.Combine(outputPath, $"{fileName}-converted.jpg");

        //                image.Save(jpgPath, ImageFormat.Jpeg);
        //            }
        //        }

        //        Console.WriteLine("\nConversie voltooid!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
        //    }
        //    return jpgImage;
        //}
    }
}
