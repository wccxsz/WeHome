using System.Data.Entity.Migrations;
using MySql.Data.Entity;
using WeHome.Data.Context;

namespace WeHome.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WeHomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }
    }
}
