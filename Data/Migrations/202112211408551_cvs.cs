namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cvs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Educations", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Competences", "CvId", "dbo.Cvs");
            DropIndex("dbo.Experiences", new[] { "CvId" });
            DropIndex("dbo.Educations", new[] { "CvId" });
            DropIndex("dbo.Competences", new[] { "CvId" });
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.Competences");
            DropTable("dbo.Cvs");
        }
    }
}
