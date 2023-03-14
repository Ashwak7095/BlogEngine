using BusinessAccessLayer.Repositories;
using DataAccessLayer.Models;
using System.Security.Cryptography;

namespace XUnit_TestCases
{
    public class BlogMockService:IBlogRepository
    {
        List<Blog> blogs = new List<Blog>();
        public BlogMockService()
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

        public void DeleteBlogById(int Id)
        {
            if (Id > 0)
            {
                blogs.Remove(GetBlogById(Id));
            }
        }

        public Blog PostBlog(Blog blog)
        {
            return new Blog()
            {
                Id = 3,
                Content = "Hooks",
                Title = "ReactJs"
            };


            //throw new NotImplementedException();
        }

        public Blog UpdateBlog(Blog blog)
        {
            return new Blog()
            {
                Id = 4,
                Content = "Locators",
                Title = "Selenium"
            };
            //throw new NotImplementedException();
        }

        Task<Blog> IBlogRepository.PostBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}