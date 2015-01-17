namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseFilters", "ExactValue_AchievmentPropertyId", "dbo.AchievmentProperties");
            DropForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes");
            DropIndex("dbo.BaseFilters", new[] { "ExactValue_AchievmentPropertyId" });
            AddColumn("dbo.BaseFilters", "ExactValue", c => c.String());
            AddColumn("dbo.BaseFilters", "Type_AchievmentPropertyTypeId1", c => c.Int());
            CreateIndex("dbo.BaseFilters", "Type_AchievmentPropertyTypeId1");
            AddForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes", "AchievmentPropertyTypeId");
            AddForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId1", "dbo.AchievmentPropertyTypes", "AchievmentPropertyTypeId");
            DropColumn("dbo.BaseFilters", "ExactValue_AchievmentPropertyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaseFilters", "ExactValue_AchievmentPropertyId", c => c.Int());
            DropForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId1", "dbo.AchievmentPropertyTypes");
            DropForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes");
            DropIndex("dbo.BaseFilters", new[] { "Type_AchievmentPropertyTypeId1" });
            DropColumn("dbo.BaseFilters", "Type_AchievmentPropertyTypeId1");
            DropColumn("dbo.BaseFilters", "ExactValue");
            CreateIndex("dbo.BaseFilters", "ExactValue_AchievmentPropertyId");
            AddForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes", "AchievmentPropertyTypeId");
            AddForeignKey("dbo.BaseFilters", "ExactValue_AchievmentPropertyId", "dbo.AchievmentProperties", "AchievmentPropertyId");
        }
    }
}
