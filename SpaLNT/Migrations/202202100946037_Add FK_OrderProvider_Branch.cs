namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFK_OrderProvider_Branch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProviders", "BranchId", c => c.Int());
            CreateIndex("dbo.OrderProviders", "BranchId");
            AddForeignKey("dbo.OrderProviders", "BranchId", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProviders", "BranchId", "dbo.Branches");
            DropIndex("dbo.OrderProviders", new[] { "BranchId" });
            DropColumn("dbo.OrderProviders", "BranchId");
        }
    }
}
