using JsonPlaceHolder.Models;
using System.Reflection;

namespace JsonPlaceHolder.Services
{
    public interface IPlaceHolderService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task AddPost(int userId, string title, string body);
        Task UpdatePost(int userId, string title, string body);
        Task DeletePost(int userId);

    }
}
