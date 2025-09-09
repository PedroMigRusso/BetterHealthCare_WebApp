using BetterHealthCare_WebApp.Models;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    public class MedicalFileService : IMedicalFileService
    {
        private readonly HttpClient _httpClient;

        public MedicalFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MedicalFileDto> UploadFileAsync(MedicalFileDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/files", dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicalFileDto>()!;
        }
    }
}
