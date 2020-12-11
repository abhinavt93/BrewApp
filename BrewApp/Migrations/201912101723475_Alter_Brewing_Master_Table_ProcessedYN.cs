namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Brewing_Master_Table_ProcessedYN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrewingMasters", "Processed_YN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BrewingMasters", "Processed_YN");
        }
    }
}
