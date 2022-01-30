namespace SpaLNT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DOB", c => c.String());
            AddColumn("dbo.Employees", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Gender");
            DropColumn("dbo.Employees", "DOB");
        }
    }
}
