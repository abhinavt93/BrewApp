namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_Customers_Warehouse : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CommonDB..Customers(CustomerName, CurrentAddress, PermanentAddress) VALUES('Baramati Warehouse', 'Pune Beer Farm Baramati', 'Pune Beer Farm Baramati')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM CommonDB..Customers WHERE CustomerName = 'Baramati Warehouse'");
        }
    }
}
