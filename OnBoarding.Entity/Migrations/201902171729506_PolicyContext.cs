namespace OnBoarding.EntityContext.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PolicyContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policy",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    PolicyId = c.Int(nullable: false),
                    Code = c.String(),
                    Premium = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PolicyBenifit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreatedOn = c.DateTime(nullable: false),
                    MaturityDate = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Policy");
        }
    }
}
