namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CurrentAddress", c => c.String());
            AddColumn("dbo.Employees", "PermanentAddress", c => c.String());
            AddColumn("dbo.Employees", "PAN", c => c.String());
            AddColumn("dbo.Employees", "Salary", c => c.String());
            DropColumn("dbo.Employees", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Employees", "Salary");
            DropColumn("dbo.Employees", "PAN");
            DropColumn("dbo.Employees", "PermanentAddress");
            DropColumn("dbo.Employees", "CurrentAddress");
        }
    }
}
