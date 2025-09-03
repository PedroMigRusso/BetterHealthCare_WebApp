using BetterHealthCare_WebApp.Models.Patients;

namespace BetterHealthCare_WebApp.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PatientDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<PatientDto>>("api/Patients");
            return response ?? new List<PatientDto>();
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var patient = await _httpClient.GetFromJsonAsync<PatientDto>($"api/patients/{id}");
            return patient ?? new PatientDto();
        }

        public async Task<bool> CreateAsync(PatientDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/patients", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, PatientDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/patients/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/patients/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
