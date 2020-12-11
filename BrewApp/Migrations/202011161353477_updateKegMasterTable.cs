namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateKegMasterTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kegs", "LastUpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Kegs", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kegs", "CreatedAt", c => c.String());
            AlterColumn("dbo.Kegs", "LastUpdatedAt", c => c.String());
        }
    }
}
