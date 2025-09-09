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
                $"api/PatientAction/ByPatient/{patientId}");
        }
    }
}
