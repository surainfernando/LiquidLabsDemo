using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.Repository.Post
{
    public interface IPostRepositoryService
    {
        Task<PostResponse> GetPostByIdAsync(int id, CancellationToken token);
    }
}
