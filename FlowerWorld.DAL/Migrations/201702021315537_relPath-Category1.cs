namespace FlowerWorld.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relPathCategory1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "smallPath", c => c.String());
            AddColumn("dbo.Categories", "largePath", c => c.String());
            DropColumn("dbo.Categories", "relPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "relPath", c => c.String());
            DropColumn("dbo.Categories", "largePath");
            DropColumn("dbo.Categories", "smallPath");
        }
    }
}