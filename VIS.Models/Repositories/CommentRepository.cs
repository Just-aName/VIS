using VIS.Models.Db;
using System.Data.Entity;

namespace VIS.Models.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>
    {
        public CommentRepository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
