namespace FlowerWorld.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "smallPath", c => c.String());
            AddColumn("dbo.Products", "largePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "largePath");
            DropColumn("dbo.Products", "smallPath");
        }
    }
}
