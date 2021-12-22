namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class many2manyApplicationuserprojects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ApplicationUserProject1");
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "ProjectId" });
            DropTable("dbo.ApplicationUserProjects");
            RenameTable(name: "dbo.ApplicationUserProject1", newName: "ApplicationUserProjects");
        }
    }
}
