namespace BetterHealthCare_WebApp.Models.Patients
{
    public class PatientDetailsViewModel
    {
        public PatientDto Patient { get; set; }
        public List<PatientActionDto> Actions { get; set; } = new();
    }
}
