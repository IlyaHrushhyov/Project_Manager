namespace IBA_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ObjectiveId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(),
                        Check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectiveId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectives", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Objectives", new[] { "ProjectId" });
            DropTable("dbo.Objectives");
        }
    }
}
