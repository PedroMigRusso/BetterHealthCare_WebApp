namespace BetterHealthCare_WebApp.Models.Patients
{
    public class CreatePatientActionDto
    {
        public int ProcedureId { get; set; }
        public List<int>? FilesId { get; set; } = new List<int>();
        public DateTime DateOfProcedure { get; set; }
    }
}
