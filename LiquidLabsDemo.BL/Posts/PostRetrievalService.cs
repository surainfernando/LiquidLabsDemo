using LiquidLabsDemo.DTO.DTO.Common;
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
        public async Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token)
        {
           return await _iPostDataService.GetPostByIdAsync(id, token);
        }

        public async Task<PaginationList<PostResponse>> GetPagintedPostsAsync(int pageSize, int pageNumber, CancellationToken token)
        {
            return await _iPostDataService.GetPagintedPostsAsync(pageSize, pageNumber, token);
        }
    }
}
