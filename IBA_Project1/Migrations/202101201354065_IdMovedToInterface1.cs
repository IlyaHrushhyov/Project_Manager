namespace IBA_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdMovedToInterface1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        SecondName = c.String(nullable: false, maxLength: 20),
                        Login = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
            AddColumn("dbo.Objectives", "TargetUserId", c => c.Int());
            AlterColumn("dbo.Objectives", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Objectives", "TargetUserId");
            AddForeignKey("dbo.Objectives", "TargetUserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectives", "TargetUserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.Objectives", new[] { "TargetUserId" });
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Objectives", "Name", c => c.String());
            DropColumn("dbo.Objectives", "TargetUserId");
            DropTable("dbo.Users");
            DropTable("dbo.UserProjects");
        }
    }
}
