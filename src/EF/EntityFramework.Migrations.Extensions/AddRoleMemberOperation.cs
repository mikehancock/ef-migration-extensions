namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity.Migrations.Model;

    public class AddRoleMemberOperation : MigrationOperation
    {
        public AddRoleMemberOperation(string roleName, string username)
            : base(null)
        {
            Username = username;
            RoleName = roleName;
        }

        public string Username { get; private set; }

        public string RoleName { get; private set; }

        public override bool IsDestructiveChange
        {
            get
            {
                return false;
            }
        }
    }
}
