using LiquidLabsDemo.DTO.DTO.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidLabsDemo.ApiManager.Posts
{
    public interface IPostApiService
    {
        public Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token);
    }
}
