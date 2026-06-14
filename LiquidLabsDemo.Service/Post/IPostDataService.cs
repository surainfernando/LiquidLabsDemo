using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.Service.Post
{
    public interface IPostDataService
    {
        public Task<PostResponse> GetPostByIdAsync(int id, CancellationToken token);
    }
}
