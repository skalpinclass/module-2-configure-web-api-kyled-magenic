using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi
{
    public class BlogContext : DbContext
    {
        public DbSet<Entities.Blog> Blogs { get; set; }
        public BlogContext(DbContextOptions options) : base(options)
        { }
    }
}
