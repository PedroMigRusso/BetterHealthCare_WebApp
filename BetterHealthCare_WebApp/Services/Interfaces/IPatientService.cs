using BetterHealthCare_WebApp.Models.Patients;

namespace BetterHealthCare_WebApp.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(PatientDto dto);
        Task<bool> UpdateAsync(int id, PatientDto dto);
        Task<bool> DeleteAsync(int id);
        Task<PatientDto?> GetWithActionsAsync(int id);
    }
}
