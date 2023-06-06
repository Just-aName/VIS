using VIS.Models.Db;
using System.Data.Entity;


namespace VIS.Models.Repositories
{
    public class ReportRepository : RepositoryBase<Report>
    {
        public ReportRepository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
