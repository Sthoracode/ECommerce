using ECommerce.Models;

namespace ECommerce.Infrastructure
{
    public static class FileActions
    {
        public static string UploadFile(IFormFile formFile)
        {
            string uniqueFile = null;
            if (formFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");
                uniqueFile = formFile.FileName;
                string filePath = Path.Combine(folder, uniqueFile);
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    formFile.CopyTo(fs);
                }
                return "images\\products\\" + uniqueFile;
            }
            return string.Empty;
        }
        public static void DeleteFile(Photo photo)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string fullPath = Path.Combine(folder, photo.Path);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}
