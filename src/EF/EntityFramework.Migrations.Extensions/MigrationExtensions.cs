namespace EntityFramework.Migrations.Extensions
{
    using System.ComponentModel;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Data.Entity.Migrations.Model;

    public static class MigrationsExtensions
    {
        public static void CreateOrAlterView(this DbMigration migration, string viewName, string viewqueryString)
        {
            ((IDbMigration)migration).AddOperation(new DropViewOperation(viewName));
            ((IDbMigration)migration).AddOperation(new CreateViewOperation(viewName, viewqueryString));
        }

        public static void DropView(this DbMigration migration, string viewName)
        {
            ((IDbMigration)migration).AddOperation(new DropViewOperation(viewName));
        }

        public static void CreateSchema(this DbMigration migration, string schemaName)
        {
            ((IDbMigration)migration).AddOperation(new CreateSchemaOperation(schemaName));
        }

        public static void DropSchema(this DbMigration migration, string schemaName)
        {
            ((IDbMigration)migration).AddOperation(new DropSchemaOperation(schemaName));
        }

        public static void GrantPermission(this DbMigration migration, string objectName, string userOrRoleName, Permission permission)
        {
            ((IDbMigration)migration).AddOperation(new GrantPermissionOperation(objectName, userOrRoleName, permission));
        }

        public static void CreateUserWithLogin(this DbMigration migration, string username, string password)
        {
            ((IDbMigration)migration).AddOperation(new CreateUserWithLoginOperation(username, password));
        }

        public static void AddRoleMember(this DbMigration migration, string roleName, string username)
        {
            ((IDbMigration)migration).AddOperation(new AddRoleMemberOperation(roleName, username));
        }
    }
}
