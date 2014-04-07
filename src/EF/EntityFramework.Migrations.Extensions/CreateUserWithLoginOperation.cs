namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity.Migrations.Model;

    public class CreateUserWithLoginOperation : MigrationOperation
    {
        public CreateUserWithLoginOperation(string username, string password)
            : base(null)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public override bool IsDestructiveChange
        {
            get
            {
                return false;
            }
        }
    }
}
