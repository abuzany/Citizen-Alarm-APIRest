namespace IRAPIREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alerts", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Alerts", "CraetionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alerts", "CraetionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Alerts", "CreationDate");
        }
    }
}
