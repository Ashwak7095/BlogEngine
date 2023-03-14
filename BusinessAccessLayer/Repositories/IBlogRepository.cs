using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlog();
        Blog GetBlogById(int Id);
        Task<Blog> PostBlog(Blog blog);
        Blog UpdateBlog(Blog blog);
        void DeleteBlogById(int Id);
    }
}
