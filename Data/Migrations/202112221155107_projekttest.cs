namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projekttest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "UserId");
            AddForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropColumn("dbo.Projects", "UserId");
        }
    }
}
