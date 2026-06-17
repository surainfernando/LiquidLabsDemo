using LiquidLabsDemo.DTO.DTO.Post;
using entityModels= LiquidLabsDemo.Repository.DTO;

namespace LiquidLabsDemo.Repository.Post
{
    public interface IPostRepositoryService
    {
        Task<entityModels.Post?> GetPostByIdAsync(int id, CancellationToken token);
        public Task CreatePostAsync(entityModels.Post post, CancellationToken token);
    }
}
