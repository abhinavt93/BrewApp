namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStockMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ingredient_Name = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockMasters");
        }
    }
}
