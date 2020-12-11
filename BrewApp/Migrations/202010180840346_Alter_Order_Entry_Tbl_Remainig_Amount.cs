namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Order_Entry_Tbl_Remainig_Amount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderEntries", "Amount_Paid", c => c.Double(nullable: false));
            AddColumn("dbo.OrderEntries", "Remaining_Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderEntries", "Remaining_Amount");
            DropColumn("dbo.OrderEntries", "Amount_Paid");
        }
    }
}
