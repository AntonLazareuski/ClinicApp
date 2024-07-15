namespace ClinicApp.Models
{
    public class ClinicListData
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public List<ClinicListItem> Clinics { get; set; }
    }
}
