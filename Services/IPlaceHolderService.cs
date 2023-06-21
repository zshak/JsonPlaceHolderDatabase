using JsonPlaceHolder.Models;

namespace JsonPlaceHolder.Services
{
    public interface IPlaceHolderService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task<List<Comment>> GetCommentsById(int id);
        Task<List<Comment>> GetCommentsByIdQuery(int id);
    }
}
