using System.Data.Entity;
using MySql.Data.Entity;
using WeHome.Entities;

namespace WeHome.Data.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WeHomeContext : DbContext
    {
        public WeHomeContext()
            : base("name=WeHomeContext")
        {
        }

        /// <summary>
        /// 系统账号
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        public DbSet<Baby> Babies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<WeHomeContext>(null);

            //多对多映射
            modelBuilder.Entity<Role>().HasMany(t => t.Users)
                .WithMany(t => t.Roles).Map(t => t.MapLeftKey("F_RoleID").MapRightKey("F_UserID").ToTable("T_UserRole"));
        }
    }
}
