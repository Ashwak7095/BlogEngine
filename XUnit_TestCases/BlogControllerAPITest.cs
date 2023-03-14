using BusinessAccessLayer.Repositories;
using DataAccessLayer.Models;
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
    public class BlogControllerAPITest
    {
        private readonly Mock<BlogMockService> _iBlogService;
        private readonly BlogController _controller;
        public BlogControllerAPITest()
        {
            _iBlogService = new Mock<BlogMockService>();
            _controller = new BlogController(_iBlogService.Object);
        }
        [Fact]
        public async Task GetAllBlogReturnOkResult()
        {
            //Arrange

            //Act
            IActionResult actionResult = await _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }
        [Fact]
        public void GetByBlogIdReturnOkResult()
        {
            //Arrange
            int id = 2;

            //Act
            IActionResult actionResult = _controller.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);

        }
        [Fact]
        public void DeleteBlogByidReturnOkResult()
        {
            //Arrange
            int id = 1;

            //Act
            IActionResult actionResult = _controller.DeleteById(id);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);

        }
        
        [Fact]
        public void GetByBlogIdReturnBadResult()
        {
            //Arrange

            int id = 0;
            //Act
            IActionResult actionResult = _controller.GetById(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);

        }
        [Fact]
        public void DeleteBlogByidReturnBadResult()
        {
            //Arrange
            int id = 0;

            //Act
            IActionResult actionResult = _controller.DeleteById(id);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);

        }
        [Fact]
        public async Task PostBlogByidReturnOkResult()
        {
            //Arrange
            Blog blog = new Blog();

            //Act
            IActionResult actionResult = await _controller.Post(blog);

            //Assert
            Assert.IsType<BadRequestResult>(actionResult);

        }
        [Fact]
        public void UpdateBlogByidReturnOkResult()
        {
            //Arrange
            Blog blg = new Blog();

            //Act
            IActionResult actionResult = _controller.Update(blg);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);

        }



    }
}
