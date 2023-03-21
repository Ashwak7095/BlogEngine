using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnit_TestCases
{
    public class PostMockService
    {
        public static List<PostModel> GetPostModels() 
        {
            return new List<PostModel>()
            {
                new PostModel
                {
                    Id = 1,
                    Title= "Java",
                    Description= "Java is a object oreinted programming language",
                    PublishDate= DateTime.Now
                },
                new PostModel
                {
                    Id = 2,
                    Title= "Selenium",
                    Description= "It is a free open source tool",
                    PublishDate= DateTime.Now
                }
            };
        }
    }
}
