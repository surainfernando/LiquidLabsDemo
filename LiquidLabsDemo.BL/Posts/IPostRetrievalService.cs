using LiquidLabsDemo.DTO.DTO.Common;
using LiquidLabsDemo.DTO.DTO.Post;

namespace LiquidLabsDemo.BL.Posts
{
    public interface IPostRetrievalService
    {
        public Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token);
        public Task<PaginationList<PostResponse>> GetPagintedPostsAsync(int pageSize, int pageNumber, CancellationToken token);
    }
}
