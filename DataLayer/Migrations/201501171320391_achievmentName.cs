namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class achievmentName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievments", "Name");
        }
    }
}
