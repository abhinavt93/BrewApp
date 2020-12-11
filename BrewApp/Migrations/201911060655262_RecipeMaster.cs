namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        Malt = c.Int(nullable: false),
                        Hops = c.Int(nullable: false),
                        Yeast = c.Int(nullable: false),
                        Water = c.Int(nullable: false),
                        OrangePeels = c.Int(nullable: false),
                        Coriander = c.Int(nullable: false),
                        FilterSheets = c.Int(nullable: false),
                        CleaningChemicals = c.Int(nullable: false),
                        Iodine = c.Int(nullable: false),
                        Enzymes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecipeMasters");
        }
    }
}
