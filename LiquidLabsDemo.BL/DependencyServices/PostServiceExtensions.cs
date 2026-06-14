using LiquidLabsDemo.ApiManager.Posts;
using LiquidLabsDemo.BL.Posts;
using LiquidLabsDemo.Repository.Post;
using LiquidLabsDemo.Service.Post;
using Microsoft.Extensions.DependencyInjection;

namespace LiquidLabsDemo.BL.DependencyServices
{
    public static  class PostServiceExtensions
    { 
        public static IServiceCollection AddPostInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepositoryService, PostRepositoryService>();
            services.AddScoped<IPostApiService, PostApiService>();
            services.AddTransient<IPostDataService, PostDataService>();
            services.AddTransient<IPostRetrievalService, PostRetrievalService>();

            return services;
        }
    }
}
