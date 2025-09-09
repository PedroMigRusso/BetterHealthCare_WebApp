using System.ComponentModel.DataAnnotations;

namespace BetterHealthCare_WebApp.Models.Patients
{
    public class AddPatientActionViewModel
    {
        public int PatientId { get; set; }

        [Required]
        public int SelectedProcedureId { get; set; }

        [Required]
        public DateTime DateOfProcedure { get; set; }

        // Novo: ficheiros
        public List<IFormFile> UploadedFiles { get; set; } = new List<IFormFile>();

        public IEnumerable<ProcedureDto> AvailableProcedures { get; set; } = new List<ProcedureDto>();
    }
}
