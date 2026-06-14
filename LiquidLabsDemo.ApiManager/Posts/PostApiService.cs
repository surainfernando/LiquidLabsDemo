using LiquidLabsDemo.ApiManager.Service;
using LiquidLabsDemo.DTO.DTO.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiquidLabsDemo.ApiManager.Posts
{
    public class PostApiService : IPostApiService
    {
        private readonly IHttpService _iHttpService;
        public PostApiService(IHttpService iHttpService)
        {
            _iHttpService = iHttpService;
        }
        public async Task<PostResponse?> GetPostByIdAsync(int id, CancellationToken token)
        {
            var json = await _iHttpService.GetAsync($"posts/{id}", token);
            if (json == null) return null;
            var response= JsonSerializer.Deserialize<GetPostResponse>( json,new JsonSerializerOptions
             {
               PropertyNameCaseInsensitive = true
             });

            if (response == null) return null;

            return new PostResponse()
            {
                UserId=response.userId,
                Id = response.id,
                Title = response.title,
                Body=response.body
            };
        }
    }
}
