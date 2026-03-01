using BetterHealthCare_WebApp.Models.Patients;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    public class PatientActionService : IPatientActionService
    {
        private readonly HttpClient _httpClient;

        public PatientActionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddActionAsync(int patientId, CreatePatientActionDto action)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/patients/{patientId}/actions", action);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PatientActionDto>> GetByPatientIdAsync(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PatientActionDto>>(
                $"api/patients/{patientId}/actions");
        }

        public async Task<bool> DeleteActionAsync(int patientId, int actionId)
        {
            var response = await _httpClient.DeleteAsync($"api/patients/{patientId}/actions/{actionId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PatientActionDto?> GetByIdAsync(int patientId, int actionId) {
            return await _httpClient.GetFromJsonAsync<PatientActionDto>(
            $"api/patients/{patientId}/actions/{actionId}");
        }
    }
}
