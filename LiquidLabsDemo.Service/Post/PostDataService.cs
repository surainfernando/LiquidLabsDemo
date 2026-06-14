using LiquidLabsDemo.ApiManager.Posts;
using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Repository.Post;

namespace LiquidLabsDemo.Service.Post
{
    public class PostDataService : IPostDataService
    {
        private readonly IPostRepositoryService _iPostRepositoryService;
        private readonly IPostApiService _iPostApiService;
        public PostDataService(IPostRepositoryService iPostRepositoryService, IPostApiService iPostApiService)
        {
            _iPostRepositoryService = iPostRepositoryService;
            _iPostApiService = iPostApiService;
        }
        public async Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token)
        {
            return await _iPostApiService.GetPostByIdAsync(id,token);
            //return await _iPostRepositoryService.GetPostByIdAsync(id, token);
        }
    }
}
