using LiquidLabsDemo.BL.Posts;
using LiquidLabsDemo.DTO.DTO.Common;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponse>> GetById(int id,CancellationToken token)
        {
           var response= await _iPostRetrievalService.GetPostByIdAsync(id, token);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<PaginationList<PostResponse>>> GetPaginatedList(int pageSize,int pageNumber, CancellationToken token)
        {
            return Ok(await _iPostRetrievalService.GetPagintedPostsAsync(pageSize, pageNumber, token));
        }
    }
}
