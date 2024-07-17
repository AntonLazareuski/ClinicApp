using ClinicApp.Data;
using ClinicApp.Models;
using ClinicApp.Services.Interfaces;

namespace ClinicApp.Services
{
    public class ClinicService: IClinicService
    {
        private readonly ClickHouseDbContext _dbContext;

        public ClinicService (ClickHouseDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public ClinicData GetClinic(int idClinic, string[] columns)
        {
            IQueryable<ClinicData> query = _dbContext.ClinicData;

            if (columns != null && columns.Length > 0)
                query = query.Select(c => new ClinicData
                {
                    ClinicId = c.ClinicId,              
                });

            var result = query.FirstOrDefault(c => c.ClinicId == idClinic);

            var clinicData = new ClinicData
            {
                Timestamp = result.Timestamp,
                ClinicId = result.ClinicId,
                ClinicName = result.ClinicName,
                TariffName = result.TariffName,
                StageId = result.StageId,
                AccountManager = result.AccountManager,
                AccountManagerPhoto = result.AccountManagerPhoto
            };

            return clinicData;
        }

        /*public ClinicListData GetClinics(int page, string[] columns)
        {
            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            IQueryable<ClinicListItem> query = _dbContext.ClinicListItem.Select(c => new ClinicListItem
            {
                ClinicId = c.ClinicId,
                ClinicName = c.ClinicName
            });

            var clinics = query.Skip(skip).Take(pageSize).ToList();
            var response = new ClinicListData
            {
                Page = page,
                Pages = (int)Math.Ceiling((double)query.Count() / pageSize),
                Clinics = clinics
            };

            return response;
        }*/
    }
}
