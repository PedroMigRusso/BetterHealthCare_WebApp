using BetterHealthCare_WebApp.Models;

namespace BetterHealthCare_WebApp.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureDto>> GetAllAsync();
        Task<ProcedureDto?> GetByIdAsync(int id);
        Task<ProcedureDto> CreateAsync(ProcedureDto dto);
        Task<ProcedureDto> UpdateAsync(int id, ProcedureDto dto);
        Task DeleteAsync(int id);
    }
}
