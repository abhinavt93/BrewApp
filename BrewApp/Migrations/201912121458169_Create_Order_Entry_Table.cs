namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Order_Entry_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Recipeid = c.Int(nullable: false),
                        RecipeName = c.String(),
                        Order_Quantity = c.Double(nullable: false),
                        Production_Price = c.Double(nullable: false),
                        Customer_Cost = c.Double(nullable: false),
                        GST = c.Double(nullable: false),
                        Margin = c.Double(nullable: false),
                        Trasportation_Cost = c.Double(nullable: false),
                        Sales_Person = c.String(),
                        Customer_Restaurant_Details = c.String(),
                        Remark = c.String(),
                        Created_By = c.String(),
                        Created_At = c.DateTime(nullable: false),
                        RecipeMaster_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeMasters", t => t.RecipeMaster_id)
                .Index(t => t.RecipeMaster_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderEntries", "RecipeMaster_id", "dbo.RecipeMasters");
            DropIndex("dbo.OrderEntries", new[] { "RecipeMaster_id" });
            DropTable("dbo.OrderEntries");
        }
    }
}
