using BetterHealthCare_WebApp.Models.Patients;
using BetterHealthCare_WebApp.Services.Interfaces;

namespace BetterHealthCare_WebApp.Services
{
    /// <summary>
    /// Service for managing patient actions/procedures via API calls
    /// </summary>
    public class PatientActionService : IPatientActionService
    {
        private readonly HttpClient _httpClient;

        public PatientActionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Adds a new action/procedure to a patient
        /// </summary>
        /// <param name="patientId">Patient ID</param>
        /// <param name="action">Action data to add</param>
        public async Task AddActionAsync(int patientId, CreatePatientActionDto action)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/patients/{patientId}/actions", action);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Retrieves all actions for a specific patient
        /// </summary>
        /// <param name="patientId">Patient ID</param>
        /// <returns>Collection of actions for the patient</returns>
        public async Task<IEnumerable<PatientActionDto>> GetByPatientIdAsync(int patientId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PatientActionDto>>(
                $"api/patients/{patientId}/actions");
        }

        /// <summary>
        /// Deletes an action from a patient
        /// </summary>
        /// <param name="patientId">Patient ID</param>
        /// <param name="actionId">Action ID to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteActionAsync(int patientId, int actionId)
        {
            var response = await _httpClient.DeleteAsync($"api/patients/{patientId}/actions/{actionId}");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Retrieves a specific action for a patient
        /// </summary>
        /// <param name="patientId">Patient ID</param>
        /// <param name="actionId">Action ID</param>
        /// <returns>Action details or null if not found</returns>
        public async Task<PatientActionDto?> GetByIdAsync(int patientId, int actionId) {
            return await _httpClient.GetFromJsonAsync<PatientActionDto>(
            $"api/patients/{patientId}/actions/{actionId}");
        }
    }
}
