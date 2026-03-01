using BetterHealthCare_WebApp.Models;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    /// <summary>
    /// Service for managing procedures via API calls
    /// </summary>
    public class ProcedureService : IProcedureService
    {
        private readonly HttpClient _httpClient;

        public ProcedureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves all procedures
        /// </summary>
        /// <returns>Collection of all procedures</returns>
        public async Task<IEnumerable<ProcedureDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProcedureDto>>("api/Procedure");
        }

        /// <summary>
        /// Retrieves a specific procedure by ID
        /// </summary>
        /// <param name="id">Procedure ID</param>
        /// <returns>Procedure details or null if not found</returns>
        public async Task<ProcedureDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProcedureDto>($"api/Procedure/{id}");
        }

        /// <summary>
        /// Creates a new procedure
        /// </summary>
        /// <param name="dto">Procedure data to create</param>
        /// <returns>Created procedure</returns>
        public async Task<ProcedureDto> CreateAsync(ProcedureDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Procedure", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProcedureDto>();
        }

        /// <summary>
        /// Updates an existing procedure
        /// </summary>
        /// <param name="id">Procedure ID to update</param>
        /// <param name="dto">Updated procedure data</param>
        /// <returns>Updated procedure</returns>
        public async Task<ProcedureDto> UpdateAsync(int id, ProcedureDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Procedure/{id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProcedureDto>();
        }

        /// <summary>
        /// Deletes a procedure
        /// </summary>
        /// <param name="id">Procedure ID to delete</param>
        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Procedure/{id}");
        }
    }
}
