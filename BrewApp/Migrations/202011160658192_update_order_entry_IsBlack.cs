namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_order_entry_IsBlack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderEntries", "IsBlack", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderEntries", "IsBlack");
        }
    }
}
