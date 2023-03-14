using BusinessAccessLayer.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface_Layer.Controllers;

namespace XUnit_TestCases
{
    public class BlogControllerAPITest
    {
        private readonly BlogController _controller;
        private readonly Mock<BlogService> _iBlogService;
        private readonly Mock<ILogger> _logger;   
        
        public BlogControllerAPITest(ILogger<BlogController> logger)
        {
            _iBlogService = new Mock<BlogService>();
            _logger = new Mock<ILogger>();
            //_controller = new BlogController(_iBlogService.Object);
    

        }
    }
}
