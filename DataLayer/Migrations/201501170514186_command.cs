namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class command : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.BaseFilters", "Command_CommandId", c => c.Int());
            CreateIndex("dbo.BaseFilters", "Command_CommandId");
            AddForeignKey("dbo.BaseFilters", "Command_CommandId", "dbo.Commands", "CommandId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "ParentCommand_CommandId", "dbo.Commands");
            DropForeignKey("dbo.BaseFilters", "Command_CommandId", "dbo.Commands");
            DropIndex("dbo.BaseFilters", new[] { "Command_CommandId" });
            DropIndex("dbo.Commands", new[] { "ParentCommand_CommandId" });
            DropColumn("dbo.BaseFilters", "Command_CommandId");
            DropTable("dbo.Commands");
        }
    }
}
