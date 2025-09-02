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

        public async Task CreateAsync(PatientDto patient)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Patient", patient);
            response.EnsureSuccessStatusCode();
        }

        // Outros métodos: GetByIdAsync, UpdateAsync, DeleteAsync...
    }
}
