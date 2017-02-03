namespace FlowerWorld.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relPathCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "relPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "relPath");
        }
    }
}
