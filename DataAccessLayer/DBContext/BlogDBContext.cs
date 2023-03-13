using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBContext
{
    public class BlogDBContext:DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options)
         : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
