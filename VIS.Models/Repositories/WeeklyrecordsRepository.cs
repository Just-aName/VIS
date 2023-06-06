using VIS.Models.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Repositories
{
    class WeeklyrecordsRepository : RepositoryBase<Weeklyrecords>
    {
        public WeeklyrecordsRepository(DbContext DbContext) : base(DbContext)
        {

        }
    }
}
