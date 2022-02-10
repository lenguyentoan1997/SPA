namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUniqueProviderCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Providers", "ProviderCode", c => c.String(maxLength: 450));
            CreateIndex("dbo.Providers", "ProviderCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Providers", new[] { "ProviderCode" });
            AlterColumn("dbo.Providers", "ProviderCode", c => c.String());
        }
    }
}
