using VIS.Models.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS.Models.Repositories
{
    public class ActivityRepository:RepositoryBase<Activity>
    {
        public ActivityRepository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
