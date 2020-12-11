namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Stock_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockMasters", "Quantity", c => c.String());
            AlterColumn("dbo.StockMasters", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockMasters", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StockMasters", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
