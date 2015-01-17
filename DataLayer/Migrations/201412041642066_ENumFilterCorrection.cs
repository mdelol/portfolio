namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ENumFilterCorrection : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BaseFilters", name: "ExactValue_EnumPropertyId", newName: "ExactValue_EnumPropertyTypeValueId");
            RenameIndex(table: "dbo.BaseFilters", name: "IX_ExactValue_EnumPropertyId", newName: "IX_ExactValue_EnumPropertyTypeValueId");
            AddColumn("dbo.BaseFilters", "Type_EnumPropertyTypeId", c => c.Int());
            CreateIndex("dbo.BaseFilters", "Type_EnumPropertyTypeId");
            AddForeignKey("dbo.BaseFilters", "Type_EnumPropertyTypeId", "dbo.EnumPropertyTypes", "EnumPropertyTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseFilters", "Type_EnumPropertyTypeId", "dbo.EnumPropertyTypes");
            DropIndex("dbo.BaseFilters", new[] { "Type_EnumPropertyTypeId" });
            DropColumn("dbo.BaseFilters", "Type_EnumPropertyTypeId");
            RenameIndex(table: "dbo.BaseFilters", name: "IX_ExactValue_EnumPropertyTypeValueId", newName: "IX_ExactValue_EnumPropertyId");
            RenameColumn(table: "dbo.BaseFilters", name: "ExactValue_EnumPropertyTypeValueId", newName: "ExactValue_EnumPropertyId");
        }
    }
}
