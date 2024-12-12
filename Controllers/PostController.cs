using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Interfaces;
using PracticeAPI.Models;
using PracticeAPI.Services;

namespace PracticeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    
    
    public PostService PostService = new PostService();

    [HttpGet]
    public List<Post> Get()
    {
        var result = PostService.GetPosts();
        return result;
    }

    [HttpGet("{id}")]
    public Post Get(int id)
    {
        var result = PostService.GetPostById(id);
        return result;
    }

    [HttpPost]
    public bool Post(Post post)
    {
        var result = PostService.AddPost(post);
        return result;
    }

    [HttpPut("{id}")]
    public bool Put(int id, Post post)
    {
        var result = PostService.UpdatePost(post);
        return result;
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var result = PostService.DeletePost(id);
        return result;
    }
}