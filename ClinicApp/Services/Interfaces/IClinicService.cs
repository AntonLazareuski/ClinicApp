using ClinicApp.Models;

namespace ClinicApp.Services.Interfaces
{
    public interface IClinicService
    {
        ClinicData GetClinic(int idClinic, string[] columns);
        /*ClinicListData GetClinics(int page, string[] columns);*/
    }
}
