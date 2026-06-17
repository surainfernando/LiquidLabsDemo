using LiquidLabsDemo.DTO.DTO.Common;
using LiquidLabsDemo.DTO.DTO.Post;
using LiquidLabsDemo.Repository.DBServices;
using LiquidLabsDemo.Repository.DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
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
        public async  Task<PaginationList<PostResponse>> GetPagintedPostsAsync(int pageSize, int pageNumber, CancellationToken token)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            await connection.OpenAsync();
            using var command = new SqlCommand(@"
                                                SELECT
                                                p.UserId,
                                                p.Id,
                                                p.Title,
                                                p.Body,
                                                COUNT(*) OVER() AS TotalCount
                                                FROM Post p
                                                ORDER BY p.Id
                                                OFFSET @Offset ROWS
                                                FETCH NEXT @PageSize ROWS ONLY;"
                                                , connection);

            command.Parameters.AddWithValue("@Offset", (pageNumber - 1)* pageSize);
            command.Parameters.AddWithValue("@PageSize", pageSize);

            List<PostResponse> list = new();
            using var reader = await command.ExecuteReaderAsync();
            int RowCount = 0;
            while (await reader.ReadAsync())
            {
                list.Add(new PostResponse
                {
                   
                    UserId = reader.IsDBNull(0) ? null : reader.GetInt32(0),
                    Id = reader.GetInt32(1),
                    Title = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Body = reader.IsDBNull(3) ? null : reader.GetString(3)
                });
                RowCount = reader.GetInt32(4);
            }

            var model = new PaginationList<PostResponse>()
            {
                List=list,
                PageNumber=pageNumber,
                PageSize=pageSize
            };

            return model;
        }
    }
    
    }
