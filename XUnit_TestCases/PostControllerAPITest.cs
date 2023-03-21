using BusinessAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
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
    public class PostControllerAPITest
    {
        private readonly Mock<IPostRepository> _iPostRepository;
        private readonly PostController _controller;
        private readonly Mock<ILogger<PostController>> _logger;
        public PostControllerAPITest()
        {
            _iPostRepository= new Mock<IPostRepository>();
            _logger = new Mock<ILogger<PostController>>();
            _controller = new PostController(_iPostRepository.Object, _logger.Object);
        }
        [Fact]
        public async Task GetPost_ShouldReturn200Status()
        {
            _iPostRepository.Setup(x=>x.GetPost()).ReturnsAsync(PostMockService.GetPostModels());

            var actionResult = await _controller.Get();

            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(actionResult);
            
        }
    }
}
