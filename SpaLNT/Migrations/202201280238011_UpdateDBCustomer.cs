namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Avatar", c => c.String());
            AlterColumn("dbo.Customers", "DOB", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Avatar");
        }
    }
}
