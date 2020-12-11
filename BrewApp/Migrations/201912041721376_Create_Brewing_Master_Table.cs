namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Brewing_Master_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrewingMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Recipeid = c.Int(nullable: false),
                        RecipeName = c.String(),
                        Quantity = c.Double(nullable: false),
                        BrewingTime = c.DateTime(nullable: false),
                        RecipeMaster_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeMasters", t => t.RecipeMaster_id)
                .Index(t => t.RecipeMaster_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrewingMasters", "RecipeMaster_id", "dbo.RecipeMasters");
            DropIndex("dbo.BrewingMasters", new[] { "RecipeMaster_id" });
            DropTable("dbo.BrewingMasters");
        }
    }
}
