using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Repository.DBServices;
using LiquidLabsDemo.Repository.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using entityModels = LiquidLabsDemo.Repository.DTO;

namespace LiquidLabsDemo.Repository.Post
{
    public class PostRepositoryService : IPostRepositoryService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public PostRepositoryService(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory= dbConnectionFactory;
        }
        public async Task<entityModels.Post?> GetPostByIdAsync(int id, CancellationToken token)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            await connection.OpenAsync();
            using var command = new SqlCommand("select InternalId,UserId,Id,Title,Body from  Post where Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using var reader = await command.ExecuteReaderAsync();
            entityModels.Post post = new();

            if (await reader.ReadAsync())
            {
                post.InternalId = reader.GetInt32(0);
                post.UserId = reader.IsDBNull(1)?null:reader.GetInt32(1);
                post.Id = reader.GetInt32(2);
                post.Title = reader.IsDBNull(3) ? null : reader.GetString(3);
                post.Body = reader.IsDBNull(4) ? null : reader.GetString(4);
            }
            return post.Id!=0? post:null;
        }

        public async Task CreatePostAsync(entityModels.Post post, CancellationToken token)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            await connection.OpenAsync();
            using var command = new SqlCommand(
                    "Insert into Post(UserId,Id,Title,Body) values(@UserId,@Id,@Title,@Body)",
                     connection);

           command.Parameters.AddWithValue("@UserId", post.UserId);
           command.Parameters.AddWithValue("@Id",post.Id);
           command.Parameters.AddWithValue("@Title", post.Title);
           command.Parameters.AddWithValue("@Body", post.Body);

            await command.ExecuteNonQueryAsync();
        }
    }
    public class Car1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
