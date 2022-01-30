namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImgAvatar", c => c.String());
            AddColumn("dbo.Products", "Thumbnail1", c => c.String());
            AddColumn("dbo.Products", "Thumbnail2", c => c.String());
            AddColumn("dbo.Products", "Thumbnail3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Thumbnail3");
            DropColumn("dbo.Products", "Thumbnail2");
            DropColumn("dbo.Products", "Thumbnail1");
            DropColumn("dbo.Products", "ImgAvatar");
        }
    }
}
