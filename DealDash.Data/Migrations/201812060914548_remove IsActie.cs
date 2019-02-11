namespace DealDash.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIsActie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Auctions", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
