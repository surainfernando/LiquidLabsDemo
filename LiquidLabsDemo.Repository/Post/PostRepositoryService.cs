using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.Repository.Post
{
    public class PostRepositoryService : IPostRepositoryService
    {
        public async Task<PostResponse> GetPostByIdAsync(int id, CancellationToken token)
        {
            return new PostResponse();
        }
    }
}
