using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using Ef;

namespace MigrationsDemo
{
    public class BlogContext : DbContext
    {
        public BlogContext():base(Connections.ConnectionString)
        {

        }
        
        public DbSet<Blog> Blogs { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }
}