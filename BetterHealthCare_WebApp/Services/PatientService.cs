using BetterHealthCare_WebApp.Models.Patients;

namespace BetterHealthCare_WebApp.Services
{
    /// <summary>
    /// Service for managing patient operations via API calls
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves all patients from the API
        /// </summary>
        /// <returns>List of all patients or empty list if no patients exist</returns>
        public async Task<List<PatientDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<PatientDto>>("api/Patients");
            return response ?? new List<PatientDto>();
        }

        /// <summary>
        /// Retrieves a specific patient by ID
        /// </summary>
        /// <param name="id">Patient ID to retrieve</param>
        /// <returns>Patient details or empty patient if not found</returns>
        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var patient = await _httpClient.GetFromJsonAsync<PatientDto>($"api/patients/{id}");
            return patient ?? new PatientDto();
        }

        /// <summary>
        /// Creates a new patient via API
        /// </summary>
        /// <param name="dto">Patient data to create</param>
        /// <returns>True if creation was successful, false otherwise</returns>
        public async Task<bool> CreateAsync(PatientDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/patients", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Updates an existing patient via API
        /// </summary>
        /// <param name="id">Patient ID to update</param>
        /// <param name="dto">Updated patient data</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public async Task<bool> UpdateAsync(int id, PatientDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/patients/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Deletes a patient via API
        /// </summary>
        /// <param name="id">Patient ID to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/patients/{id}");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Retrieves a patient with all associated actions/procedures
        /// </summary>
        /// <param name="id">Patient ID to retrieve</param>
        /// <returns>Patient details with actions or null if not found</returns>
        public async Task<PatientDto?> GetWithActionsAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<PatientDto>($"api/patients/{id}/full");
            return response;
            // ou /withactions conforme ajustaste no API
        }
    }
}
