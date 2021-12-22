namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecvs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Competences", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Educations", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Experiences", "CvId", "dbo.Cvs");
            DropIndex("dbo.Competences", new[] { "CvId" });
            DropIndex("dbo.Educations", new[] { "CvId" });
            DropIndex("dbo.Experiences", new[] { "CvId" });
            DropTable("dbo.Cvs");
            DropTable("dbo.Competences");
            DropTable("dbo.Educations");
            DropTable("dbo.Experiences");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CvId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Experiences", "CvId");
            CreateIndex("dbo.Educations", "CvId");
            CreateIndex("dbo.Competences", "CvId");
            AddForeignKey("dbo.Experiences", "CvId", "dbo.Cvs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Educations", "CvId", "dbo.Cvs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Competences", "CvId", "dbo.Cvs", "Id", cascadeDelete: true);
        }
    }
}
