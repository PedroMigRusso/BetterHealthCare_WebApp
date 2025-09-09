using BetterHealthCare_WebApp.Models;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly HttpClient _httpClient;

        public ProcedureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProcedureDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProcedureDto>>("api/Procedure");
        }

        public async Task<ProcedureDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProcedureDto>($"api/Procedure/{id}");
        }

        public async Task<ProcedureDto> CreateAsync(ProcedureDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Procedure", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProcedureDto>();
        }

        public async Task<ProcedureDto> UpdateAsync(int id, ProcedureDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Procedure/{id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProcedureDto>();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Procedure/{id}");
        }
    }
}
