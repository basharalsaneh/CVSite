namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "imageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "imageUrl");
        }
    }
}
