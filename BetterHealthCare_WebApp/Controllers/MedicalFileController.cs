using BetterHealthCare_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterHealthCare_WebApp.Controllers
{
    public class MedicalFileController : Controller
    {
        private readonly IMedicalFileService _fileService;

        public MedicalFileController(IMedicalFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(int id)
        {
            var file = await _fileService.GetByIdAsync(id);
            if (file == null || string.IsNullOrEmpty(file.Base64))
                return NotFound();

            var bytes = Convert.FromBase64String(file.Base64);
            return File(bytes, "image/jpeg");
        }

        // (Optional) show file info on a page
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var file = await _fileService.GetByIdAsync(id);
            if (file == null)
                return NotFound();

            return View(file);
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id, string? fileName = null)
        {
            var file = await _fileService.GetByIdAsync(id);
            if (file == null || string.IsNullOrEmpty(file.Base64))
                return NotFound();

            var bytes = Convert.FromBase64String(file.Base64);
            string downloadName = fileName ?? $"MedicalFile_{id}.jpg"; // or use original file name if stored
            return File(bytes, "application/octet-stream", downloadName);
        }
    }
}
