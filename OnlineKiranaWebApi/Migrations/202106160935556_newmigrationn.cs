namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrationn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UserTypeId");
        }
    }
}
