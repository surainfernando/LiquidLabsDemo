using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Repository.Post;

namespace LiquidLabsDemo.Service.Post
{
    public class PostDataService : IPostDataService
    {
        private readonly IPostRepositoryService _iPostRepositoryService;
        public PostDataService(IPostRepositoryService iPostRepositoryService)
        {
            _iPostRepositoryService = iPostRepositoryService;
        }
        public async Task<PostResponse> GetPostByIdAsync(int id, CancellationToken token)
        {
            return await _iPostRepositoryService.GetPostByIdAsync(id, token);
        }
    }
}
