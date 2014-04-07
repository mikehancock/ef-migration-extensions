namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            base.Generate(migrationOperation);

            this.GenerateCreateView(migrationOperation as CreateViewOperation);
            this.GenerateDropView(migrationOperation as DropViewOperation);
            this.GenerateAddRoleMember(migrationOperation as AddRoleMemberOperation);
            this.GenerateCreateSchema(migrationOperation as CreateSchemaOperation);
            this.GenerateDropSchema(migrationOperation as DropSchemaOperation);
            this.GenerateCreateUserWithLogin(migrationOperation as CreateUserWithLoginOperation);
            this.GenerateGrantPermission(migrationOperation as GrantPermissionOperation);
        }

        protected override void Generate(CreateUserWithLoginOperation createUserWithLoginOperation)
        {
            base.Generate(createUserWithLoginOperation);
            this.GenerateCreateUserWithLogin(createUserWithLoginOperation);
        }

        private void GenerateCreateView(CreateViewOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("CREATE VIEW {0} AS {1} ; ", operation.ViewName, operation.ViewString);
                    Statement(writer);
                }
            }
        }

        private void GenerateDropView(DropViewOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("IF EXISTS (SELECT 1 FROM sys.views where name = '{0}')", operation.ViewName);
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   DROP VIEW {0}", operation.ViewName);
                    writer.WriteLine("END;");
                    Statement(writer);
                }
            }
        }

        private void GenerateAddRoleMember(AddRoleMemberOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("EXEC sp_addrolemember '{0}', '{1}';", operation.RoleName, operation.Username);
                    Statement(writer);
                }
            }
        }

        private void GenerateCreateSchema(CreateSchemaOperation operation)
        {
            if (operation != null)
            {
               using (var writer = Writer())
                {
                    writer.WriteLine("CREATE SCHEMA {0} ; ", operation.SchemaName);
                    Statement(writer);
                }
            }
        }

        private void GenerateDropSchema(DropSchemaOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("DROP SCHEMA {0} ; ", operation.SchemaName);
                    Statement(writer);
                }
            }
        }

        private void GenerateCreateUserWithLogin(CreateUserWithLoginOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("IF NOT EXISTS (SELECT loginname from master.dbo.syslogins WHERE name = '{0}')", operation.Username);
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("	CREATE LOGIN {0} WITH PASSWORD = '{1}';", operation.Username, operation.Password);
                    writer.WriteLine("END");
                    writer.WriteLine("CREATE USER {0} FROM LOGIN {0};", operation.Username);
                    Statement(writer);
                }
            }
        }

        private void GenerateGrantPermission(GrantPermissionOperation operation)
        {
            if (operation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine("GRANT {0} ON {1} TO {2}", operation.Permission.ToString().ToUpper(), operation.DbObject, operation.UserOrRoleName);
                    Statement(writer);
                }
            }
        }
    }
}
