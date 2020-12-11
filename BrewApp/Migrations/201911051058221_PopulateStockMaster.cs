namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStockMaster : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Malt', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Hops', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Yeast', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Water', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('OrangePeels', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Coriander', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('FilterSheets', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('CleaningChemicals', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Iodine', 0, 0)");
            Sql("INSERT INTO StockMasters (Ingredient_Name, Price,Quantity) VALUES ('Enzymes', 0, 0)");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM StockMasters WHERE Ingredient_Name in ('Malt','Hops','Yeast','Water','Orange peels','Coriander','Filter sheets','Cleaning chemicals','Iodine','Enzymes')");
        }
    }
}
