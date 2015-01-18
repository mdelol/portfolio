namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId", "dbo.Achievments");
            AddColumn("dbo.AchievmentProperties", "Achievment_AchievmentId1", c => c.Int());
            CreateIndex("dbo.AchievmentProperties", "Achievment_AchievmentId1");
            AddForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId1", "dbo.Achievments", "AchievmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId1", "dbo.Achievments");
            DropIndex("dbo.AchievmentProperties", new[] { "Achievment_AchievmentId1" });
            DropColumn("dbo.AchievmentProperties", "Achievment_AchievmentId1");
            AddForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId", "dbo.Achievments", "AchievmentId");
        }
    }
}
