using BetterHealthCare_WebApp.Models;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    /// <summary>
    /// Service for managing medical files via API calls
    /// </summary>
    public class MedicalFileService : IMedicalFileService
    {
        private readonly HttpClient _httpClient;

        public MedicalFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Uploads a new medical file
        /// </summary>
        /// <param name="dto">Medical file data to upload</param>
        /// <returns>Uploaded medical file with ID</returns>
        public async Task<MedicalFileDto> UploadFileAsync(MedicalFileDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/files", dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MedicalFileDto>()!;
        }

        /// <summary>
        /// Retrieves a medical file by ID
        /// </summary>
        /// <param name="id">Medical file ID</param>
        /// <returns>Medical file data or null if not found</returns>
        public async Task<MedicalFileDto?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/files/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[MedicalFileService] Error {response.StatusCode}: {content}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<MedicalFileDto>();
        }

    }
}
