namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complexfilter1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseFilters", "ComplexFilter_BaseFilterId", c => c.Int());
            CreateIndex("dbo.BaseFilters", "ComplexFilter_BaseFilterId");
            AddForeignKey("dbo.BaseFilters", "ComplexFilter_BaseFilterId", "dbo.BaseFilters", "BaseFilterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseFilters", "ComplexFilter_BaseFilterId", "dbo.BaseFilters");
            DropIndex("dbo.BaseFilters", new[] { "ComplexFilter_BaseFilterId" });
            DropColumn("dbo.BaseFilters", "ComplexFilter_BaseFilterId");
        }
    }
}
