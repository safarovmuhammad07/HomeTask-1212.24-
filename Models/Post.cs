namespace PracticeAPI.Models;

public class Post
{
    public int PostId{ get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
}