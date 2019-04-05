namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "adminka_ID", "dbo.Adminkas");
            DropIndex("dbo.Blogs", new[] { "adminka_ID" });
            RenameColumn(table: "dbo.Blogs", name: "adminka_ID", newName: "AdminkaID");
            AlterColumn("dbo.Blogs", "AdminkaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "AdminkaID");
            AddForeignKey("dbo.Blogs", "AdminkaID", "dbo.Adminkas", "ID", cascadeDelete: true);
            DropColumn("dbo.Blogs", "BlogUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.Blogs", "AdminkaID", "dbo.Adminkas");
            DropIndex("dbo.Blogs", new[] { "AdminkaID" });
            AlterColumn("dbo.Blogs", "AdminkaID", c => c.Int());
            RenameColumn(table: "dbo.Blogs", name: "AdminkaID", newName: "adminka_ID");
            CreateIndex("dbo.Blogs", "adminka_ID");
            AddForeignKey("dbo.Blogs", "adminka_ID", "dbo.Adminkas", "ID");
        }
    }
}
