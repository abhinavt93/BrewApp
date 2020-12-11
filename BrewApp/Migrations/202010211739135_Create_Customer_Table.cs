namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Customer_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        FatherName = c.String(),
                        Email = c.String(),
                        MotherName = c.String(),
                        CurrentAddress = c.String(),
                        PermanentAddress = c.String(),
                        MobNo = c.String(),
                        DOB = c.DateTime(),
                        PAN = c.String(),
                        Salary = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
