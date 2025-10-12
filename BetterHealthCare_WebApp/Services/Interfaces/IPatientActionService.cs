using BetterHealthCare_WebApp.Models.Patients;

namespace BetterHealthCare_WebApp.Services.Interfaces
{
    public interface IPatientActionService
    {
        Task<IEnumerable<PatientActionDto>> GetByPatientIdAsync(int patientId);
        Task AddActionAsync(int patientId, CreatePatientActionDto action);
        Task<bool> DeleteActionAsync(int patientId, int actionId);
        Task<PatientActionDto?> GetByIdAsync(int patientId, int actionId);
    }
}
