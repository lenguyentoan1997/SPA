namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Avatar");
        }
    }
}
