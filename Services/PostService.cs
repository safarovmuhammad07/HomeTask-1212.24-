using Dapper;
using PracticeAPI.DataContext;
using PracticeAPI.Interfaces;
using PracticeAPI.Models;

namespace PracticeAPI.Services;

public class PostService: IPostService
{
    private DaperContext _context;

    public PostService()
    {
        _context = new DaperContext();
    }
    
    public List<Post> GetPosts()
    {
        return _context.GetConnection().Query<Post>("SELECT * FROM Post").ToList();
    }

    public Post? GetPostById(int id)
    {
        return _context.GetConnection().Query<Post>("SELECT * FROM Post WHERE PostId = @id", new { id }).FirstOrDefault();
    }

    public bool AddPost(Post post)
    {
        return _context.GetConnection()
            .Execute("Insert into Post(Title,Content,Created) values  (@Title,@Content,@Created)", post) > 0;
    }

    public bool UpdatePost(Post post)
    {
        return _context.GetConnection().Execute("Update Post set Title=@Title, Content=@Content, Created=@Created where id=@id",post) >0;
    }

    public bool DeletePost(int id)
    {
        return _context.GetConnection().Execute("Delete Post where Id=@id", new { id }) > 0;
    }
}