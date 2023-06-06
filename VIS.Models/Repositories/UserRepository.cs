using VIS.Models.Db;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace VIS.Models.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext DbContext) : base(DbContext)
        {
        }

        public override IQueryable<User> GetManyQueryable(Expression<Func<User, bool>> predicate = null, params string[] includeProps)
        {
            var rolePropArray = new string[] { nameof(Role) };
            if (includeProps == null)
            {
                includeProps = rolePropArray;
            }
            else if (!includeProps.Contains(nameof(Role)))
            {
                includeProps = includeProps.Concat(rolePropArray).ToArray();
            }

            return base.GetManyQueryable(predicate, includeProps);
        }
    }
}
