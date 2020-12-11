namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableKegMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kegs",
                c => new
                    {
                        KegID = c.Int(nullable: false, identity: true),
                        KegNumber = c.String(),
                        CurrentLocation = c.String(),
                        PreviousLocation = c.String(),
                        LastUpdatedAt = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.KegID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kegs");
        }
    }
}
