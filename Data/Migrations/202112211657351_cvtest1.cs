namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cvtest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Competence = c.String(),
                        Education = c.String(),
                        Experience = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cvs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cvs", new[] { "UserId" });
            DropTable("dbo.Cvs");
        }
    }
}
