namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Brewing_Master_Table_ProductionCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrewingMasters", "ProductionCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BrewingMasters", "ProductionCost");
        }
    }
}
