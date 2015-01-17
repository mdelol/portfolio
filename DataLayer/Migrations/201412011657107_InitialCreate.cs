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
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievmentId);
            
            CreateTable(
                "dbo.AchievmentProperties",
                c => new
                    {
                        AchievmentPropertyId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Achievment_AchievmentId = c.Int(),
                        Type_AchievmentPropertyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.AchievmentPropertyId)
                .ForeignKey("dbo.Achievments", t => t.Achievment_AchievmentId)
                .ForeignKey("dbo.AchievmentPropertyTypes", t => t.Type_AchievmentPropertyTypeId)
                .Index(t => t.Achievment_AchievmentId)
                .Index(t => t.Type_AchievmentPropertyTypeId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AchievmentProperties", "Type_AchievmentPropertyTypeId", "dbo.AchievmentPropertyTypes");
            DropForeignKey("dbo.AchievmentProperties", "Achievment_AchievmentId", "dbo.Achievments");
            DropIndex("dbo.AchievmentProperties", new[] { "Type_AchievmentPropertyTypeId" });
            DropIndex("dbo.AchievmentProperties", new[] { "Achievment_AchievmentId" });
            DropTable("dbo.AchievmentPropertyTypes");
            DropTable("dbo.AchievmentProperties");
            DropTable("dbo.Achievments");
        }
    }
}
