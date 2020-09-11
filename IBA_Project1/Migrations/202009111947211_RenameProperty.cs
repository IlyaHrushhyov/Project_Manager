namespace IBA_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProperty : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Objectives");
            DropColumn("dbo.Objectives", "ObjectiveId");
            AddColumn("dbo.Objectives", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Objectives", "Id");
            /*DropColumn("dbo.Objectives", "ObjectiveId");*/
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objectives", "ObjectiveId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Objectives");
            DropColumn("dbo.Objectives", "Id");
            AddPrimaryKey("dbo.Objectives", "ObjectiveId");
        }
    }
}
