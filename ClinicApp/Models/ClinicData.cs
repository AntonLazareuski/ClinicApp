namespace ClinicApp.Models
{
    public class ClinicData
    {
        public DateTime Timestamp { get; set; }
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? TariffName { get; set; }
        public int StageId { get; set; }
        public string? AccountManager { get; set; }
        public string? AccountManagerPhoto { get; set; }
    }
}
