using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElectronicStore.Services
{
    public class UploadService
    {
        public async Task Upload(string path, string fileName, IFormFile file)
        {
            await using var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}