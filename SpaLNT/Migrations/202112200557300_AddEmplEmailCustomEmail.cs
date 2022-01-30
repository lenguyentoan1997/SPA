namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmplEmailCustomEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Employees", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Customers", "Email");
        }
    }
}
