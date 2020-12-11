namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Order_Entry_tbl_MarginAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderEntries", "Margin_Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderEntries", "Margin_Amount");
        }
    }
}
