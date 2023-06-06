using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using VIS.Models.Db;

namespace VIS.Models.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed;

        public DbContext DbContext { get; set; }

        public IRepository<Activity> ActivityRepository { get; private set; }

        public IRepository<User> UserRepository { get; private set; }

        public IRepository<Comment> CommentRepository { get; private set; }

        public IRepository<Meal> MealRepository { get; private set; }

        public IRepository<Dailyrecords> DailyrecordsRepository { get; private set; }

        public IRepository<Report> ReportRepository { get; private set; }

        public IRepository<Usersettings> UsersettingsRepository { get; private set; }

        public IRepository<Weeklyrecords> WeeklyrecordsRepository { get; private set; }

        public EFUnitOfWork()
        {
            DbContext = new DbEntities();

            ActivityRepository = new ActivityRepository(DbContext);
            CommentRepository = new CommentRepository(DbContext);
            MealRepository = new MealRepository(DbContext);
            UserRepository = new UserRepository(DbContext);
            DailyrecordsRepository = new DailyrecordsRepository(DbContext);
            ReportRepository = new ReportRepository(DbContext);
            UsersettingsRepository = new UsersettingsRepository(DbContext);
            WeeklyrecordsRepository = new WeeklyrecordsRepository(DbContext);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    if (DbContext.ChangeTracker.Entries().Any(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
                    {
                        DbContext.SaveChanges();
                    }

                    DbContext.Dispose();
                }
            }

            disposed = true;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

    }
}

