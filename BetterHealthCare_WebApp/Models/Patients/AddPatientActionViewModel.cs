using System.ComponentModel.DataAnnotations;

namespace BetterHealthCare_WebApp.Models.Patients
{
    public class AddPatientActionViewModel
    {
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Procedure")]
        public int SelectedProcedureId { get; set; }

        [Required]
        [Display(Name = "Date of Procedure")]
        public DateTime DateOfProcedure { get; set; }

        public IEnumerable<ProcedureDto> AvailableProcedures { get; set; } = new List<ProcedureDto>();
    }
}
