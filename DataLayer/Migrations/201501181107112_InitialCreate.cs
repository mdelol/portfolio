namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievments",
                c => new
                    {
                        AchievmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievmentId);
            
            CreateTable(
                "dbo.EnumProperties",
                c => new
                    {
                        EnumPropertyId = c.Int(nullable: false, identity: true),
                        Achievment_AchievmentId = c.Int(),
                        SelectedValue_EnumPropertyTypeValueId = c.Int(),
                        Type_EnumPropertyTypeId = c.Int(),
                        Achievment_AchievmentId1 = c.Int(),
                    })
                .PrimaryKey(t => t.EnumPropertyId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId)
                .ForeignKey("dbo.EnumPropertyTypeValues", t => t.SelectedValue_EnumPropertyTypeValueId)
                .ForeignKey("dbo.EnumPropertyTypes", t => t.Type_EnumPropertyTypeId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId1, cascadeDelete: true)
                .Index(t => t.Achievment_AchievmentId)
                .Index(t => t.SelectedValue_EnumPropertyTypeValueId)
                .Index(t => t.Type_EnumPropertyTypeId)
                .Index(t => t.Achievment_AchievmentId1);
            
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
            
            CreateTable(
                "dbo.AchievmentProperties",
                c => new
                    {
                        AchievmentPropertyId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        TypeId = c.Int(nullable: false),
                        Achievment_AchievmentId = c.Int(),
                        Achievment_AchievmentId1 = c.Int(),
                    })
                .PrimaryKey(t => t.AchievmentPropertyId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId)
                .ForeignKey("dbo.AchievmentPropertyTypes", t => t.TypeId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId1, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.Achievment_AchievmentId)
                .Index(t => t.Achievment_AchievmentId1);
            
            CreateTable(
                "dbo.AchievmentPropertyTypes",
                c => new
                    {
                        AchievmentPropertyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        ApplicableToTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievmentPropertyTypeId);
            
            CreateTable(
                "dbo.BaseFilters",
                c => new
                    {
                        BaseFilterId = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(),
                        ExactValue = c.String(),
                        LowerValue = c.Double(),
                        UpperValue = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ComplexFilter_BaseFilterId = c.Int(),
                        ExactValue_EnumPropertyTypeValueId = c.Int(),
                        Type_EnumPropertyTypeId = c.Int(),
                        Command_CommandId = c.Int(),
                    })
                .PrimaryKey(t => t.BaseFilterId)
                .ForeignKey("dbo.AchievmentPropertyTypes", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.BaseFilters", t => t.ComplexFilter_BaseFilterId)
                .ForeignKey("dbo.EnumPropertyTypeValues", t => t.ExactValue_EnumPropertyTypeValueId)
                .ForeignKey("dbo.EnumPropertyTypes", t => t.Type_EnumPropertyTypeId)
                .ForeignKey("dbo.Commands", t => t.Command_CommandId)
                .Index(t => t.TypeId)
                .Index(t => t.ComplexFilter_BaseFilterId)
                .Index(t => t.ExactValue_EnumPropertyTypeValueId)
                .Index(t => t.Type_EnumPropertyTypeId)
                .Index(t => t.Command_CommandId);
            
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCommand_CommandId = c.Int(),
                    })
                .PrimaryKey(t => t.CommandId)
                .ForeignKey("dbo.Commands", t => t.ParentCommand_CommandId)
                .Index(t => t.ParentCommand_CommandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "ParentCommand_CommandId", "dbo.Commands");
            DropForeignKey("dbo.BaseFilters", "Command_CommandId", "dbo.Commands");
            DropForeignKey("dbo.BaseFilters", "Type_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropForeignKey("dbo.BaseFilters", "ExactValue_EnumPropertyTypeValueId", "dbo.EnumPropertyTypeValues");
            DropForeignKey("dbo.BaseFilters", "ComplexFilter_BaseFilterId", "dbo.BaseFilters");
            DropForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId1", "dbo.Achievments");
            DropForeignKey("dbo.AchievmentProperties", "TypeId", "dbo.AchievmentPropertyTypes");
            DropForeignKey("dbo.BaseFilters", "TypeId", "dbo.AchievmentPropertyTypes");
            DropForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId", "dbo.Achievments");
            DropForeignKey("dbo.EnumProperties", "Achievment_AchievmentId1", "dbo.Achievments");
            DropForeignKey("dbo.EnumProperties", "Type_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropForeignKey("dbo.EnumProperties", "SelectedValue_EnumPropertyTypeValueId", "dbo.EnumPropertyTypeValues");
            DropForeignKey("dbo.EnumPropertyTypeValues", "EnumPropertyType_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropForeignKey("dbo.EnumProperties", "Achievment_AchievmentId", "dbo.Achievments");
            DropIndex("dbo.Commands", new[] { "ParentCommand_CommandId" });
            DropIndex("dbo.BaseFilters", new[] { "Command_CommandId" });
            DropIndex("dbo.BaseFilters", new[] { "Type_EnumPropertyTypeId" });
            DropIndex("dbo.BaseFilters", new[] { "ExactValue_EnumPropertyTypeValueId" });
            DropIndex("dbo.BaseFilters", new[] { "ComplexFilter_BaseFilterId" });
            DropIndex("dbo.BaseFilters", new[] { "TypeId" });
            DropIndex("dbo.AchievmentProperties", new[] { "Achievment_AchievmentId1" });
            DropIndex("dbo.AchievmentProperties", new[] { "Achievment_AchievmentId" });
            DropIndex("dbo.AchievmentProperties", new[] { "TypeId" });
            DropIndex("dbo.EnumPropertyTypeValues", new[] { "EnumPropertyType_EnumPropertyTypeId" });
            DropIndex("dbo.EnumProperties", new[] { "Achievment_AchievmentId1" });
            DropIndex("dbo.EnumProperties", new[] { "Type_EnumPropertyTypeId" });
            DropIndex("dbo.EnumProperties", new[] { "SelectedValue_EnumPropertyTypeValueId" });
            DropIndex("dbo.EnumProperties", new[] { "Achievment_AchievmentId" });
            DropTable("dbo.Commands");
            DropTable("dbo.BaseFilters");
            DropTable("dbo.AchievmentPropertyTypes");
            DropTable("dbo.AchievmentProperties");
            DropTable("dbo.EnumPropertyTypes");
            DropTable("dbo.EnumPropertyTypeValues");
            DropTable("dbo.EnumProperties");
            DropTable("dbo.Achievments");
        }
    }
}
