namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity.Migrations.Model;

    public enum Permission
    {
        Select,

        Update,

        Delete
    }

    public class GrantPermissionOperation : MigrationOperation
    {
        public GrantPermissionOperation(string dbObjectName, string userOrRoleName, Permission permission)
            : base(null)
        {
            DbObject = dbObjectName;
            UserOrRoleName = userOrRoleName;
            Permission = permission;
        }

        public string DbObject { get; private set; }

        public string UserOrRoleName { get; private set; }

        public Permission Permission { get; private set; }

        public override bool IsDestructiveChange
        {
            get
            {
                return false;
            }
        }
    }
}
