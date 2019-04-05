namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobby1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adminkas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 200),
                        NickName = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Image = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                        Description = c.String(storeType: "ntext"),
                        SizeSeat = c.Int(nullable: false),
                        OpenHours = c.DateTime(nullable: false),
                        CloseHours = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        AgeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ages", t => t.AgeID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.AgeID)
                .Index(t => t.CategoryID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateID = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Dates", t => t.DateID, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: true)
                .Index(t => t.DateID)
                .Index(t => t.ProgramID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.String(nullable: false, maxLength: 50),
                        EndTime = c.String(nullable: false, maxLength: 50),
                        DayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Days", t => t.DayID, cascadeDelete: true)
                .Index(t => t.DayID);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        MonthID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Months", t => t.MonthID, cascadeDelete: true)
                .Index(t => t.MonthID);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        IconImg = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 250),
                        Image = c.String(nullable: false, maxLength: 255),
                        Tittle = c.String(nullable: false, maxLength: 450),
                        Description = c.String(nullable: false, maxLength: 4000),
                        Special = c.String(nullable: false, maxLength: 200),
                        Experience = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        SliderDesc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        BlogDesc1 = c.String(unicode: false, storeType: "text"),
                        BlogDesc2 = c.String(unicode: false, storeType: "text"),
                        Title2 = c.String(unicode: false, storeType: "text"),
                        BlogCategID = c.Int(nullable: false),
                        BlogUser = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Adminka_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adminkas", t => t.Adminka_ID)
                .ForeignKey("dbo.BlogCategs", t => t.BlogCategID, cascadeDelete: true)
                .Index(t => t.BlogCategID)
                .Index(t => t.Adminka_ID);
            
            CreateTable(
                "dbo.BlogCategs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 255),
                        Image = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GaleryBlogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageBlog = c.String(nullable: false, maxLength: 255),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GaleryBlogs", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategID", "dbo.BlogCategs");
            DropForeignKey("dbo.Blogs", "Adminka_ID", "dbo.Adminkas");
            DropForeignKey("dbo.Classes", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Schedules", "DateID", "dbo.Dates");
            DropForeignKey("dbo.Days", "MonthID", "dbo.Months");
            DropForeignKey("dbo.Dates", "DayID", "dbo.Days");
            DropForeignKey("dbo.Schedules", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Classes", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Classes", "AgeID", "dbo.Ages");
            DropIndex("dbo.GaleryBlogs", new[] { "BlogID" });
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Blogs", new[] { "Adminka_ID" });
            DropIndex("dbo.Blogs", new[] { "BlogCategID" });
            DropIndex("dbo.Days", new[] { "MonthID" });
            DropIndex("dbo.Dates", new[] { "DayID" });
            DropIndex("dbo.Schedules", new[] { "ClassID" });
            DropIndex("dbo.Schedules", new[] { "ProgramID" });
            DropIndex("dbo.Schedules", new[] { "DateID" });
            DropIndex("dbo.Classes", new[] { "TeacherID" });
            DropIndex("dbo.Classes", new[] { "CategoryID" });
            DropIndex("dbo.Classes", new[] { "AgeID" });
            DropTable("dbo.GaleryBlogs");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogCategs");
            DropTable("dbo.Blogs");
            DropTable("dbo.Teachers");
            DropTable("dbo.Programs");
            DropTable("dbo.Months");
            DropTable("dbo.Days");
            DropTable("dbo.Dates");
            DropTable("dbo.Schedules");
            DropTable("dbo.Categories");
            DropTable("dbo.Classes");
            DropTable("dbo.Ages");
            DropTable("dbo.Adminkas");
        }
    }
}
