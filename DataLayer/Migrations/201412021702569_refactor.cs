namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnumProperties",
                c => new
                    {
                        EnumPropertyId = c.Int(nullable: false, identity: true),
                        Achievment_AchievmentId = c.Int(),
                        SelectedValue_EnumPropertyTypeValueId = c.Int(),
                        Type_EnumPropertyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.EnumPropertyId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId)
                .ForeignKey("dbo.EnumPropertyTypeValues", t => t.SelectedValue_EnumPropertyTypeValueId)
                .ForeignKey("dbo.EnumPropertyTypes", t => t.Type_EnumPropertyTypeId)
                .Index(t => t.Achievment_AchievmentId)
                .Index(t => t.SelectedValue_EnumPropertyTypeValueId)
                .Index(t => t.Type_EnumPropertyTypeId);
            
            CreateTable(
                "dbo.EnumPropertyTypeValues",
                c => new
                    {
                        EnumPropertyTypeValueId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        EnumPropertyType_EnumPropertyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.EnumPropertyTypeValueId)
                .ForeignKey("dbo.EnumPropertyTypes", t => t.EnumPropertyType_EnumPropertyTypeId)
                .Index(t => t.EnumPropertyType_EnumPropertyTypeId);
            
            CreateTable(
                "dbo.EnumPropertyTypes",
                c => new
                    {
                        EnumPropertyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicableToTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnumPropertyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnumProperties", "Type_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropForeignKey("dbo.EnumProperties", "SelectedValue_EnumPropertyTypeValueId", "dbo.EnumPropertyTypeValues");
            DropForeignKey("dbo.EnumPropertyTypeValues", "EnumPropertyType_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropForeignKey("dbo.EnumProperties", "Achievment_AchievmentId", "dbo.Achievments");
            DropIndex("dbo.EnumPropertyTypeValues", new[] { "EnumPropertyType_EnumPropertyTypeId" });
            DropIndex("dbo.EnumProperties", new[] { "Type_EnumPropertyTypeId" });
            DropIndex("dbo.EnumProperties", new[] { "SelectedValue_EnumPropertyTypeValueId" });
            DropIndex("dbo.EnumProperties", new[] { "Achievment_AchievmentId" });
            DropTable("dbo.EnumPropertyTypes");
            DropTable("dbo.EnumPropertyTypeValues");
            DropTable("dbo.EnumProperties");
        }
    }
}
