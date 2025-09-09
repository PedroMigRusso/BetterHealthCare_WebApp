using BetterHealthCare_WebApp.Models.Patients;

namespace BetterHealthCare_WebApp.Services.Interfaces
{
    public interface IPatientActionService
    {
        Task<IEnumerable<PatientActionDto>> GetByPatientIdAsync(int patientId);
    }
}
