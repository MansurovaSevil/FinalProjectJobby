namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobby2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GaleryBlogs", "ImageBlog", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GaleryBlogs", "ImageBlog", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
