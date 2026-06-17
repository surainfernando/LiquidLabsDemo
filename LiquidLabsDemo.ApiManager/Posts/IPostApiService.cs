using LiquidLabsDemo.DTO.DTO.Post;


namespace LiquidLabsDemo.ApiManager.Posts
{
    public interface IPostApiService
    {
        public Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token);
    }
}
