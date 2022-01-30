namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpaDatabaseV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingServiceId = c.Int(),
                        ServiceId = c.Int(),
                        UseServiceId = c.Int(),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingServices", t => t.BookingServiceId)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.UseServices", t => t.UseServiceId)
                .Index(t => t.BookingServiceId)
                .Index(t => t.ServiceId)
                .Index(t => t.UseServiceId);
            
            CreateTable(
                "dbo.BookingServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Date = c.String(),
                        Time = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerCode = c.String(),
                        Name = c.String(),
                        Phone = c.String(maxLength: 15),
                        IdentityCard = c.String(),
                        Job = c.String(),
                        Gender = c.String(maxLength: 5),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Type = c.String(maxLength: 6),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        CustomerId = c.Int(),
                        Discount = c.Byte(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Byte(nullable: false),
                        OrderCustomerId = c.Int(),
                        ProductDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderCustomers", t => t.OrderCustomerId)
                .ForeignKey("dbo.ProductDetails", t => t.ProductDetailId)
                .Index(t => t.OrderCustomerId)
                .Index(t => t.ProductDetailId);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(),
                        BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        Address = c.String(),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        ContactVia = c.String(maxLength: 50),
                        BranchCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(maxLength: 15),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeCode = c.String(),
                        BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.UseServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServedDate = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Note = c.String(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TypeId = c.Int(),
                        FactoryId = c.Int(),
                        ProviderId = c.Int(),
                        ImportPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExportPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCode = c.String(),
                        Discount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factories", t => t.FactoryId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .ForeignKey("dbo.Types", t => t.TypeId)
                .Index(t => t.TypeId)
                .Index(t => t.FactoryId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FactoryCode = c.String(),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProviderCode = c.String(),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Type = c.String(maxLength: 6),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        ProviderId = c.Int(),
                        Discount = c.Byte(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.ProviderOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Byte(nullable: false),
                        OrderProviderId = c.Int(),
                        ProductDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderProviders", t => t.OrderProviderId)
                .ForeignKey("dbo.ProductDetails", t => t.ProductDetailId)
                .Index(t => t.OrderProviderId)
                .Index(t => t.ProductDetailId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCode = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Byte(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDetails", "UseServiceId", "dbo.UseServices");
            DropForeignKey("dbo.BookingDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BookingDetails", "BookingServiceId", "dbo.BookingServices");
            DropForeignKey("dbo.BookingServices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrderDetails", "ProductDetailId", "dbo.ProductDetails");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Products", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.ProviderOrderDetails", "ProductDetailId", "dbo.ProductDetails");
            DropForeignKey("dbo.ProviderOrderDetails", "OrderProviderId", "dbo.OrderProviders");
            DropForeignKey("dbo.OrderProviders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Products", "FactoryId", "dbo.Factories");
            DropForeignKey("dbo.ProductDetails", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.UseServices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.CustomerOrderDetails", "OrderCustomerId", "dbo.OrderCustomers");
            DropForeignKey("dbo.OrderCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ProviderOrderDetails", new[] { "ProductDetailId" });
            DropIndex("dbo.ProviderOrderDetails", new[] { "OrderProviderId" });
            DropIndex("dbo.OrderProviders", new[] { "ProviderId" });
            DropIndex("dbo.Products", new[] { "ProviderId" });
            DropIndex("dbo.Products", new[] { "FactoryId" });
            DropIndex("dbo.Products", new[] { "TypeId" });
            DropIndex("dbo.UseServices", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.ProductDetails", new[] { "BranchId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.CustomerOrderDetails", new[] { "ProductDetailId" });
            DropIndex("dbo.CustomerOrderDetails", new[] { "OrderCustomerId" });
            DropIndex("dbo.OrderCustomers", new[] { "CustomerId" });
            DropIndex("dbo.BookingServices", new[] { "CustomerId" });
            DropIndex("dbo.BookingDetails", new[] { "UseServiceId" });
            DropIndex("dbo.BookingDetails", new[] { "ServiceId" });
            DropIndex("dbo.BookingDetails", new[] { "BookingServiceId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Services");
            DropTable("dbo.Types");
            DropTable("dbo.ProviderOrderDetails");
            DropTable("dbo.OrderProviders");
            DropTable("dbo.Providers");
            DropTable("dbo.Factories");
            DropTable("dbo.Products");
            DropTable("dbo.UseServices");
            DropTable("dbo.Employees");
            DropTable("dbo.Branches");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.CustomerOrderDetails");
            DropTable("dbo.OrderCustomers");
            DropTable("dbo.Customers");
            DropTable("dbo.BookingServices");
            DropTable("dbo.BookingDetails");
        }
    }
}
