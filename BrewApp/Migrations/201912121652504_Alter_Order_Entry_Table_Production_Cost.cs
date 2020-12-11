namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Order_Entry_Table_Production_Cost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrewingMasters", "ProductionPrice", c => c.Double(nullable: false));
            AddColumn("dbo.OrderEntries", "Production_Cost", c => c.Double(nullable: false));
            AddColumn("dbo.OrderEntries", "Customer_Price", c => c.Double(nullable: false));
            DropColumn("dbo.BrewingMasters", "ProductionCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BrewingMasters", "ProductionCost", c => c.Double(nullable: false));
            DropColumn("dbo.OrderEntries", "Customer_Price");
            DropColumn("dbo.OrderEntries", "Production_Cost");
            DropColumn("dbo.BrewingMasters", "ProductionPrice");
        }
    }
}
