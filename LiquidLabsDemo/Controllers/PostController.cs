using LiquidLabsDemo.BL.Posts;
using LiquidLabsDemo.DTO.DTO.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiquidLabsDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRetrievalService _iPostRetrievalService;
        public PostController(IPostRetrievalService iPostRetrievalService)
        {
            _iPostRetrievalService = iPostRetrievalService;

        }
        [HttpGet]
        public async Task<ActionResult<PostResponse>> GetById(int id,CancellationToken token)
        {
           var response= await _iPostRetrievalService.GetPostByIdAsync(id, token);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
