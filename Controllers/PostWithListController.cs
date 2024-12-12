using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Models;

namespace PracticeAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PostWithListController:ControllerBase
{
    private readonly List<Post?> _posts;

    [HttpGet("With_List")]
    public List<Post?> getAllPosts()
    {
        return _posts;
    }

    [HttpGet("With_List_Id")]
    public Post? getPostById(int id)
    {
        return _posts.FirstOrDefault(x => x.PostId == id);
    }

    [HttpPost("With_List")]
    public bool AddPost(Post? post)
    {
        if (post == null)
        {
            return false;
        }

        post.PostId = _posts.Count + 1;


        _posts.Add(post);

        return true;
    }


    [HttpPut("With_List")]
    public bool UpdatePost(Post? post)
    {
        if (post == null)
        {
            return false;
        }

        var existingPost = _posts.Find(p => p.PostId == post.PostId);
        if (existingPost == null)
        {
            return false;
        }

        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        existingPost.Created = post.Created;

        return true;
    }



    [HttpDelete("With_List")]
    public bool DeletePost(int id)
    {
        var existingPost = _posts.Find(p => p.PostId == id);
        return existingPost != null;
    }


}