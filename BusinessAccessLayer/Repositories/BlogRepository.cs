using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Repositories
{
    public class BlogRepository
    {
        private readonly BlogDBContext _dbContext;

        public BlogRepository(BlogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Blog>> GetBlog()
        {
            try
            {
                var query = "select * from Blogs";
                return await _dbContext.Blogs.FromSqlRaw<Blog>(query).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Blog> GetBlogById(int Id)
        {
            try
            {
                return await _dbContext.Blogs.FirstAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Blog> PostBlog(Blog blog)
        {
            try
            {
                Blog blog1 = new Blog()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    CreatedAt = DateTime.Now,
                    UserId = blog.UserId
                };
                await _dbContext.Blogs.AddAsync(blog1);
                await _dbContext.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
