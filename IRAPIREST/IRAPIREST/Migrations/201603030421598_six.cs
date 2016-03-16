namespace IRAPIREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FacebookID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FacebookID", c => c.Int(nullable: false));
        }
    }
}
