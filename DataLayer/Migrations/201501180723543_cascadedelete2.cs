namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedelete2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnumProperties", "Achievment_AchievmentId", "dbo.Achievments");
            AddColumn("dbo.EnumProperties", "Achievment_AchievmentId1", c => c.Int());
            CreateIndex("dbo.EnumProperties", "Achievment_AchievmentId1");
            AddForeignKey("dbo.EnumProperties", "Achievment_AchievmentId1", "dbo.Achievments", "AchievmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnumProperties", "Achievment_AchievmentId1", "dbo.Achievments");
            DropIndex("dbo.EnumProperties", new[] { "Achievment_AchievmentId1" });
            DropColumn("dbo.EnumProperties", "Achievment_AchievmentId1");
            AddForeignKey("dbo.EnumProperties", "Achievment_AchievmentId", "dbo.Achievments", "AchievmentId");
        }
    }
}
