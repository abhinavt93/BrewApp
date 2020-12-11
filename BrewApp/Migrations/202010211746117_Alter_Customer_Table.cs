namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Customer_Table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Salary", c => c.String());
        }
    }
}
