using DataAccessLayer.Models;

namespace XUnit_TestCases
{
    public class BlogService
    {
        List<Blog> blogs = new List<Blog>();
        public BlogService()
        {
            blogs = new List<Blog>()
            {
                new Blog()
                {
                    Id= 1,
                    Content = "Oops",
                    Title= "Java"
                },
                new Blog()
                {
                    Id= 2,
                    Content="Crud Operations",
                    Title ="Asp.Net Core"
                }
            };
        }
        public Task<List<Blog>> GetBlog()
        {
            return Task.FromResult(blogs.ToList());
        }

        public Blog GetBlogById(int Id)
        {
            return blogs.FirstOrDefault(x => x.Id == Id);
        }
    }
}