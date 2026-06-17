using LiquidLabsDemo.DTO.DTO.Common;
using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.Service.Post
{
    public interface IPostDataService
    {
        public Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token);
        public  Task<PaginationList<PostResponse>> GetPagintedPostsAsync(int pageSize, int pageNumber, CancellationToken token);

    }
}
