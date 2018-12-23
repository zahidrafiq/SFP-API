using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.Entities.DBEntities;

namespace PUCIT.AIMRL.SFP.DAL
{
    public class PRMDataContext : DbContext
    {
        private static readonly string ConnectionString = DatabaseHelper.Instance.MainDBConnectionString;

        public DbSet<SampleStudent> SampleStudents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionsMapping> PermissionsMapping { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<EmailRequest> EmailRequests { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Comments> Comments { get; set; }
    //    public DbSet<ProjectVoteMapping> ProjectVote { get; set; }
        public PRMDataContext()
            : base(ConnectionString)
        {
            // We'll eager load entities whenever required.
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 3000;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}



