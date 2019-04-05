using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JobbyProject.Models;


namespace JobbyProject.DAL
{
    public class JobbyProjectContext : DbContext
    {
        public JobbyProjectContext(): base ("JobbyProjectContext")
    {
       
    }
        public DbSet<Adminka> Adminkas { get; set; }

        public DbSet<Age> Ages { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogCateg> GetBlogCategs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Date> Dates { get; set; }

        public DbSet<Day> Days { get; set; }

        public DbSet<GaleryBlog> GaleryBlogs { get; set; }

        public DbSet<Month> Months { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

    }
}