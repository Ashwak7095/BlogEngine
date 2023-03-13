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
        Task<List<Blog>> GetCollege();
        Task<Blog> GetBlogById(int Id);
        Task<Blog> PostCollege(Blog blog);
        Blog UpdateCollege(Blog blog);
    }
}
