using JsonPlaceHolder.Models;
using RestSharp;

namespace JsonPlaceHolder.Services
{
    public class PlaceHolderService : IPlaceHolderService
    {
        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                var client = new RestClient("https://jsonplaceholder.typicode.com/");
                var request = new RestRequest("/posts", Method.Get);
                var response = await client.ExecuteAsync<List<Post>>(request);
                return response.Data;
            }
            catch 
            {
                throw new Exception();
            }
        }

        public async Task<List<Comment>> GetCommentsById(int id)
        {
            try
            {
                var client = new RestClient("https://jsonplaceholder.typicode.com/");
                var request = new RestRequest($"/posts/{id}/comments", Method.Get);
                var response = await client.ExecuteAsync<List<Comment>>(request);
                return response.Data;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<Comment>> GetCommentsByIdQuery(int id)
        {
            try
            {
                var client = new RestClient("https://jsonplaceholder.typicode.com/");
                var request = new RestRequest($"/comments", Method.Get);
                request.AddParameter("postId", Convert.ToString(id));
                var response = await client.ExecuteAsync<List<Comment>>(request);
                return response.Data;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            try
            {
                var client = new RestClient("https://jsonplaceholder.typicode.com/");
                var request = new RestRequest($"/posts/{id}", Method.Get);
                var response = await client.ExecuteAsync<Post>(request);
                return response.Data;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
