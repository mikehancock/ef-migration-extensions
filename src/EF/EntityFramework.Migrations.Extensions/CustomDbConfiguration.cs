
namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity;

    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            this.SetMigrationSqlGenerator("System.Data.SqlClient", () => new CustomSqlGenerator());
        }
    }
}
