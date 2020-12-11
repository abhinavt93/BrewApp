namespace BrewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_Recipe_Table_Int_to_Double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeMasters", "Water", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "OrangePeels", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Coriander", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "FilterSheets", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "CleaningChemicals", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Iodine", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Enzymes", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeMasters", "Enzymes", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Iodine", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "CleaningChemicals", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "FilterSheets", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Coriander", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "OrangePeels", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeMasters", "Water", c => c.Int(nullable: false));
        }
    }
}
