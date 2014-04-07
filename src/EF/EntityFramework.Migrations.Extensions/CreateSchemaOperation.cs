namespace EntityFramework.Migrations.Extensions
{
    using System.Data.Entity.Migrations.Model;

    public class CreateSchemaOperation : MigrationOperation
    {
        public CreateSchemaOperation(string schemaName)
            : base(null)
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; private set; }

        public override bool IsDestructiveChange
        {
            get
            {
                return false;
            }
        }
    }
}
