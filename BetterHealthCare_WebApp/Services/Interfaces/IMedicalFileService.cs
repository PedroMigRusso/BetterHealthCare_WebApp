using BetterHealthCare_WebApp.Models;

namespace BetterHealthCare_WebApp.Services.Interfaces
{
    public interface IMedicalFileService
    {
        Task<MedicalFileDto> UploadFileAsync(MedicalFileDto dto);
        Task<MedicalFileDto?> GetByIdAsync(int id);
    }
}
