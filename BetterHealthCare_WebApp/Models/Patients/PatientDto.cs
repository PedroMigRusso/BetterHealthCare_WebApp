namespace BetterHealthCare_WebApp.Models.Patients
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HealthNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ICollection<PatientActionDto> Actions { get; set; } = new List<PatientActionDto>();
    }
}
