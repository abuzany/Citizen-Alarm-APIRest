namespace IRAPIREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacebookID = c.String(),
                        Range = c.Double(nullable: false),
                        EnabledNotifications = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserConfigurations");
        }
    }
}
