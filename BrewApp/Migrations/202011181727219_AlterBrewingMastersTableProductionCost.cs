namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBrewingMastersTableProductionCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrewingMasters", "ProductionCost", c => c.Double(nullable: false));
            DropColumn("dbo.BrewingMasters", "ProductionPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BrewingMasters", "ProductionPrice", c => c.Double(nullable: false));
            DropColumn("dbo.BrewingMasters", "ProductionCost");
        }
    }
}
