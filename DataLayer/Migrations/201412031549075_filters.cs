namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseFilters",
                c => new
                    {
                        BaseFilterId = c.Int(nullable: false, identity: true),
                        LowerValue = c.Double(),
                        UpperValue = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ExactValue_EnumPropertyId = c.Int(),
                        ExactValue_AchievmentPropertyId = c.Int(),
                        Type_AchievmentPropertyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.BaseFilterId)
                .ForeignKey("dbo.EnumProperties", t => t.ExactValue_EnumPropertyId)
                .ForeignKey("dbo.AchievmentProperties", t => t.ExactValue_AchievmentPropertyId)
                .ForeignKey("dbo.AchievmentPropertyTypes", t => t.Type_AchievmentPropertyTypeId)
                .Index(t => t.ExactValue_EnumPropertyId)
                .Index(t => t.ExactValue_AchievmentPropertyId)
                .Index(t => t.Type_AchievmentPropertyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseFilters", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes");
            DropForeignKey("dbo.BaseFilters", "ExactValue_AchievmentPropertyId", "dbo.AchievmentProperties");
            DropForeignKey("dbo.BaseFilters", "ExactValue_EnumPropertyId", "dbo.EnumProperties");
            DropIndex("dbo.BaseFilters", new[] { "Type_AchievmentPropertyTypeId" });
            DropIndex("dbo.BaseFilters", new[] { "ExactValue_AchievmentPropertyId" });
            DropIndex("dbo.BaseFilters", new[] { "ExactValue_EnumPropertyId" });
            DropTable("dbo.BaseFilters");
        }
    }
}
