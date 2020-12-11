namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_ProductionPrice_Clm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Processed_BrewingMaster", "ProductionPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Processed_BrewingMaster", "ProductionCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Processed_BrewingMaster", "ProductionCost", c => c.Double(nullable: false));
            DropColumn("dbo.Processed_BrewingMaster", "ProductionPrice");
        }
    }
}
