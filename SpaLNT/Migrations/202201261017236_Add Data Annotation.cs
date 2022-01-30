namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "Phone", c => c.String(maxLength: 15));
        }
    }
}
