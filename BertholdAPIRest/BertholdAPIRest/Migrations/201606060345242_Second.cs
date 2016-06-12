namespace BertholdAPIRest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alerts", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alerts", "Address");
        }
    }
}
