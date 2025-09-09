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

        public async Task<IEnumerable<PatientActionDto>> GetByPatientIdAsync(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PatientActionDto>>(
                $"api/PatientAction/ByPatient/{patientId}");
        }
    }
}
