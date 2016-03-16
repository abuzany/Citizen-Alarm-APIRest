namespace IRAPIREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class four : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertTypes",
                c => new
                    {
                        AlertTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AlertTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlertTypes");
        }
    }
}
