using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Service.Post;

namespace LiquidLabsDemo.BL.Posts
{
    public class PostRetrievalService : IPostRetrievalService
    {
        private readonly IPostDataService _iPostDataService;
        public PostRetrievalService(IPostDataService iPostDataService)
        {
            _iPostDataService = iPostDataService;
        }
        public async Task<PostResponse> GetPostByIdAsync(int id, CancellationToken token)
        {
           return await _iPostDataService.GetPostByIdAsync(id, token);
        }
    }
}
