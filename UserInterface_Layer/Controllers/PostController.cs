using BusinessAccessLayer.Repositories;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _iPostRepository;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostRepository iPostRepository, ILogger<PostController> logger)
        {
            _iPostRepository = iPostRepository;
            _logger = logger;
        }
        [HttpGet("GetPost")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pm = await _iPostRepository.GetPost();
                if (pm == null)
                {
                    return NotFound("Blog Not Found");
                }
                return Ok(pm);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var p1 = _iPostRepository.GetPostById(id);
                if (p1 == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(p1);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpPost("AddBlog")]
        public async Task<IActionResult> Post([FromBody] PostModel postModel)
        {
            try
            {
                var pm = await _iPostRepository.Post(postModel);
                if (pm == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(pm);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return BadRequest();
        }
        [HttpPut("UpdateBlog")]
        public IActionResult Update([FromBody] PostModel postModel)
        {
            try
            {
                var pmdetails = _iPostRepository.Update(postModel);
                if (pmdetails == null)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(pmdetails);
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
                _iPostRepository.DeleteById(id);
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
