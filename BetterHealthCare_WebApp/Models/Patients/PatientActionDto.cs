namespace BetterHealthCare_WebApp.Models.Patients
{
    public class PatientActionDto
    {
        public int Id { get; set; }
        public ProcedureDto Procedure { get; set; } = null!;
        public List<int>? FilesId { get; set; }
        public DateTime DateOfProcedure { get; set; }
    }
}
