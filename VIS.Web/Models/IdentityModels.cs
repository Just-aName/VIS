using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VIS.Models
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ExternalLogin { get; set; }
        public string RegistrationGUID { get; set; }
        public Nullable<System.DateTime> GUIDExpirationDate { get; set; }
        public int? Trener_ID{ get; set; }
        public int? Usersettings_ID { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CustomUserRole : IdentityUserRole<int> 
    { }

    public class CustomUserClaim : IdentityUserClaim<int> 
    { }
    
    public class CustomUserLogin : IdentityUserLogin<int> 
    { }

    public class ApplicationRole : IdentityRole<int, CustomUserRole>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName)  { Name = roleName; }

        public string Description { get; set; }

    }

    public class CustomUserStore : UserStore<ApplicationUser, ApplicationRole, int,
    CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<ApplicationRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationRole>().ToTable("Role");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRole");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Id).HasColumnName("User_ID");
            modelBuilder.Entity<ApplicationRole>().Property(x => x.Id).HasColumnName("Role_ID");
            modelBuilder.Entity<CustomUserRole>().Property(x => x.RoleId).HasColumnName("Role_ID");
            modelBuilder.Entity<CustomUserRole>().Property(x => x.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<CustomUserClaim>().Property(x => x.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<CustomUserLogin>().Property(x => x.UserId).HasColumnName("User_ID");
            */
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationRole>().ToTable("Role");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRole");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<ApplicationUser>().HasKey(x => x.Id).Property(x => x.Id).HasColumnName("User_ID");
            modelBuilder.Entity<ApplicationRole>().HasKey(x => x.Id).Property(x => x.Id).HasColumnName("Role_ID");
            modelBuilder.Entity<CustomUserRole>().Property(x => x.RoleId).HasColumnName("Role_ID");
            modelBuilder.Entity<CustomUserRole>().Property(x => x.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<CustomUserClaim>().HasKey(x => x.Id).Property(x => x.Id).HasColumnName("UserClaim_ID");
            modelBuilder.Entity<CustomUserClaim>().Property(x => x.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<CustomUserLogin>().Property(x => x.UserId).HasColumnName("User_ID");

            modelBuilder.Entity<CustomUserRole>().HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<CustomUserLogin>().HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });


        }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }
    }
}