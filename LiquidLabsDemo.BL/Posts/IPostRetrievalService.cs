using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.BL.Posts
{
    public interface IPostRetrievalService
    {
        public Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token);
    }
}
