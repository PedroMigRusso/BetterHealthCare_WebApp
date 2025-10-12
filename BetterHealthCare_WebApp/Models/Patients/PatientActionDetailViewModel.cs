namespace BetterHealthCare_WebApp.Models.Patients
{
    public class PatientActionDetailViewModel
    {
        public int PatientId { get; set; }
        public PatientActionDto Action { get; set; } = null!;
        public List<MedicalFileDto> Files { get; set; } = new();
    }
}
