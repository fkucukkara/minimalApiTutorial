using Domain.Models;

namespace API.Services;
public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPost(int id);
    Task<Post> CreatePost(Post post);
    Task<Post> UpdatePost(int id, string content);
    Task DeletePost(int id);
}
