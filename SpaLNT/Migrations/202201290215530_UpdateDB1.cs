namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderCustomers", "Paid", c => c.String());
            AlterColumn("dbo.OrderCustomers", "Debt", c => c.String());
            AlterColumn("dbo.OrderCustomers", "Total", c => c.String());
            AlterColumn("dbo.CustomerOrderDetails", "Price", c => c.String());
            AlterColumn("dbo.OrderProviders", "Paid", c => c.String());
            AlterColumn("dbo.OrderProviders", "Debt", c => c.String());
            AlterColumn("dbo.OrderProviders", "Total", c => c.String());
            AlterColumn("dbo.ProviderOrderDetails", "Price", c => c.String());
            AlterColumn("dbo.Services", "Price", c => c.String());
            DropColumn("dbo.OrderCustomers", "Type");
            DropColumn("dbo.OrderProviders", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProviders", "Type", c => c.String(maxLength: 6));
            AddColumn("dbo.OrderCustomers", "Type", c => c.String(maxLength: 6));
            AlterColumn("dbo.Services", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProviderOrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderProviders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderProviders", "Debt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderProviders", "Paid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CustomerOrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderCustomers", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderCustomers", "Debt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderCustomers", "Paid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
