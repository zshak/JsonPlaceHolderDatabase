using Dapper;
using JsonPlaceHolder.Models;
using Microsoft.Extensions.Options;
using Npgsql;
using RestSharp;

namespace JsonPlaceHolder.Services
{
    public class PlaceHolderService : IPlaceHolderService
    {
        private readonly Connection _connectionStrings;

        public PlaceHolderService(IOptions<Connection> connectionStrings) {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task AddPost(int userId, string title, string body)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.ConnectionStrings))
            {
                var query = "INSERT INTO Posts (title, user_id, body) values (@title, @userId, @body)";
                await connection.ExecuteAsync(query, new {title, userId, body});
            }
        }

        public async Task DeletePost(int userId)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.ConnectionStrings))
            {
                var query = "DELETE FROM posts where user_id = @userId";
                await connection.ExecuteAsync(query, new { userId});
            }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            using(var connection = new NpgsqlConnection(_connectionStrings.ConnectionStrings))
            {
                var query = "SELECT * from posts";
                var res = await connection.QueryAsync<Post>(query);
                return res.ToList();
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.ConnectionStrings))
            {
                var query = "SELECT * from posts where id=@id";
                var res = await connection.QuerySingleOrDefaultAsync<Post>(query, new {id});
                return (Post)res;
            }
        }

        public async Task UpdatePost(int userId, string title, string body)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.ConnectionStrings))
            {
                var query = "UPDATE Posts Set title = @title, body = @body where user_id = @userId" ;
                await connection.ExecuteAsync(query, new { title, body, userId});
            }
        }


    }
}
