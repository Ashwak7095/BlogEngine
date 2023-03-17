using BusinessAccessLayer.Repositories;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface_Layer.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _iBlogRepository;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IBlogRepository iBlogRepository ,ILogger<BlogController> logger)
        {
            _iBlogRepository= iBlogRepository;
            _logger= logger;
        }
        [HttpGet("GetBlog")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var blg = await _iBlogRepository.GetBlog();
                if (blg == null)
                {
                    return NotFound("Blog Not Found");
                }
                return Ok(blg);
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpGet("GetByIdBlog")]
        public IActionResult GetById(int id) 
        {
            try
            {
                var b1 = _iBlogRepository.GetBlogById(id);
                if (b1 == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(b1);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpPost("AddBlog")]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            try
            {
                var blg = await _iBlogRepository.PostBlog(blog);
                if (blg == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(blg);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpPut("UpdateBlog")]
        public IActionResult Update([FromBody] Blog blog)
        {
            try
            {
                var blgdetails = _iBlogRepository.UpdateBlog(blog);
                if (blgdetails == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(blog);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteBlog")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _iBlogRepository.DeleteBlogById(id);
                return Ok(new { message = "user deployed" });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
    }
}
