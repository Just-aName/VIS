using VIS.Models.Db;
using System.Data.Entity;

namespace VIS.Models.Repositories
{
    public class DailyrecordsRepository : RepositoryBase<Dailyrecords>
    {
        public DailyrecordsRepository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
