namespace WorkFlowManager.Common.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHierarchyExplorerForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HierarchyExplorerForm",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        OfficerId = c.String(),
                        LineManagerId = c.String(),
                        SubDirectorId = c.String(),
                        DirectorId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseTableTbl", t => t.Id)
                .ForeignKey("dbo.TaskTbl", t => t.TaskId)
                .Index(t => t.Id)
                .Index(t => t.TaskId);
            
            AddColumn("dbo.BaseTableTbl", "OwnerId3", c => c.Int());
            AddColumn("dbo.BaseTableTbl", "Amount", c => c.Int());
            AddColumn("dbo.BaseTableTbl", "Budgeted", c => c.Boolean());
            CreateIndex("dbo.BaseTableTbl", "OwnerId3");
            AddForeignKey("dbo.BaseTableTbl", "OwnerId3", "dbo.BaseTableTbl", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HierarchyExplorerForm", "TaskId", "dbo.TaskTbl");
            DropForeignKey("dbo.HierarchyExplorerForm", "Id", "dbo.BaseTableTbl");
            DropForeignKey("dbo.BaseTableTbl", "OwnerId3", "dbo.BaseTableTbl");
            DropIndex("dbo.HierarchyExplorerForm", new[] { "TaskId" });
            DropIndex("dbo.HierarchyExplorerForm", new[] { "Id" });
            DropIndex("dbo.BaseTableTbl", new[] { "OwnerId3" });
            DropColumn("dbo.BaseTableTbl", "Budgeted");
            DropColumn("dbo.BaseTableTbl", "Amount");
            DropColumn("dbo.BaseTableTbl", "OwnerId3");
            DropTable("dbo.HierarchyExplorerForm");
        }
    }
}
