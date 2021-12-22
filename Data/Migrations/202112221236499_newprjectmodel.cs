namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprjectmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UserId" });
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Projects", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropTable("dbo.ProjectApplicationUsers");
            CreateIndex("dbo.Projects", "UserId");
            AddForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
