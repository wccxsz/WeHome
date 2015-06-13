using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using WeHome.Entities;

namespace WeHome.Data.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<WeHomeContext>(null);

            //多对多映射
            modelBuilder.Entity<Role>().HasMany(t => t.Users)
                .WithMany(t => t.Roles).Map(t => t.MapLeftKey("F_RoleID").MapRightKey("F_UserID").ToTable("T_UserRole"));
        }
    }
}
