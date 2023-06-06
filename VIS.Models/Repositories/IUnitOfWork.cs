using VIS.Models.Db;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace VIS.Models.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; set; }

        IRepository<Activity> ActivityRepository { get; }

        IRepository<User> UserRepository { get; }

        IRepository<Comment> CommentRepository { get; }

        IRepository<Meal> MealRepository { get; }

        IRepository<Dailyrecords> DailyrecordsRepository { get; }

        IRepository<Report> ReportRepository { get; }

        IRepository<Usersettings> UsersettingsRepository { get; }
        
        IRepository<Weeklyrecords> WeeklyrecordsRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
