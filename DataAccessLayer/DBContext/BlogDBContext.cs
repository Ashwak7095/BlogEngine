using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseSqlServer("Data Source=MLI01093;Initial Catalog=BlogDB;Integrated Security=True;TrustServerCertificate=True");

    }
}
