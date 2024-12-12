using PracticeAPI.Models;

namespace PracticeAPI.Interfaces;

public interface IPostService
{
    List<Post> GetPosts();
    Post GetPostById(int id);
    bool AddPost(Post post);
    bool UpdatePost(Post post);
    bool DeletePost(int id);
}