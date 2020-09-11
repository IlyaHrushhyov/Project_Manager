namespace IBA_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCheckProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Objectives", "Check");
            DropColumn("dbo.Projects", "Check");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Check", c => c.Boolean(nullable: false));
            AddColumn("dbo.Objectives", "Check", c => c.Boolean(nullable: false));
        }
    }
}
