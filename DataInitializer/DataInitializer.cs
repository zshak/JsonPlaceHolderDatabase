using Dapper;
using JsonPlaceHolder.Models;
using Npgsql;
using System.Text.Json;

namespace JsonPlaceHolder.DataInitializer
{
    internal class DataInitializer
    {
        public DataInitializer()
        {

        }
        private static bool DataBaseExists(string connectionString)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT COUNT(*) FROM posts", connection))
                {
                    int tableCount = Convert.ToInt32(command.ExecuteScalar());

                    if (tableCount == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        public static async Task InitializeDataAsync(string connectionString)
        {
               
            try
            {
                if (DataBaseExists(connectionString)) return;
                List<Post> products = new List<Post>();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage ms = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                    String jsonString = await ms.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(jsonString);
                    products = JsonSerializer.Deserialize<List<Post>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                }
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    var query = "INSERT INTO Posts (id, title, user_id, body) values (@id, @title, @userId, @body)";
                    foreach(Post item in products)
                    {
                        int a = await connection.ExecuteAsync(query, item);
                    }                
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
