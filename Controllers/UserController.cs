using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Models;
using PracticeAPI.Services;

namespace PracticeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    public UserService userService = new UserService();
    [HttpGet]
    public List<User> Get()
    {
        var result = userService.GetUsers();
        return result;
    }

    [HttpGet("{id}")]
    public User GetUserById(int id)
    {
        var result = userService.GetUserById(id);
        return result;
    }

    [HttpPost]
    public bool Post(User user)
    {
        var res = userService.AddUser(user);
        return res;
    }

    [HttpPut("{id}")]
    public bool Put(int id, User user)
    {
        var res = userService.UpdateUser(user);
        return res;
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var res = userService.DeleteUser(id);
        return res;
    }
    
}