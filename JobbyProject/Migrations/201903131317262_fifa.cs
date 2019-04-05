namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Image", c => c.String(nullable: true, maxLength: 255));
        }
    }
}
