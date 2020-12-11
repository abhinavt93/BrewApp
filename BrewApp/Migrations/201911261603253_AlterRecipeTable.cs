namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRecipeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeMasters", "Malt", c => c.String());
            AlterColumn("dbo.RecipeMasters", "Hops", c => c.String());
            AlterColumn("dbo.RecipeMasters", "Yeast", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeMasters", "Yeast", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Hops", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Malt", c => c.Int(nullable: false));
        }
    }
}
