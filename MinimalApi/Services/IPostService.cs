using Domain.Models;

namespace MinimalApi.Services
{
    public interface IPostService
    {
        Task<IList<Post>> GetAllPosts();
        Task<Post> GetPost(int id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(int id, string content);
        Task DeletePost(int id);
    }
}
