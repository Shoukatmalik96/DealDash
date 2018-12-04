namespace DealDash.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuctionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "ActualAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "ActualAmount");
        }
    }
}
