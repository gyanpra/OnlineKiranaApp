namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetypeid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "UserTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserTypeId", c => c.Int(nullable: false));
        }
    }
}
