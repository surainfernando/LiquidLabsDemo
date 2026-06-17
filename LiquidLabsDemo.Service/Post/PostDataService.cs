using LiquidLabsDemo.ApiManager.Posts;
using LiquidLabsDemo.DTO.DTO.Common;
using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Repository.Post;
using entityModels = LiquidLabsDemo.Repository.DTO;

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
            var postDBRecord=await _iPostRepositoryService.GetPostByIdAsync(id, token);
            if (postDBRecord != null)
            {
                return new PostResponse()
                {
                    Id=postDBRecord.Id,
                    UserId=postDBRecord.UserId,
                    Body=postDBRecord.Body,
                    Title=postDBRecord.Title
                };
            }
            
            var postFromAPIService=await _iPostApiService.GetPostByIdAsync(id,token);
            if (postFromAPIService != null)
            {
                await _iPostRepositoryService.CreatePostAsync(new entityModels.Post()
                {
                    Id = postFromAPIService.Id,
                    UserId = postFromAPIService.UserId,
                    Body = postFromAPIService.Body,
                    Title = postFromAPIService.Title
                }, token);
                return postFromAPIService;
            }
            return null;
          
        }

        public async Task<PaginationList<PostResponse>> GetPagintedPostsAsync(int pageSize, int pageNumber, CancellationToken token)
        {
            return await _iPostRepositoryService.GetPagintedPostsAsync(pageSize, pageNumber, token);
        }
    }
}
