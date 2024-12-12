using Dapper;
using Npgsql.Internal;
using PracticeAPI.DataContext;
using PracticeAPI.Interfaces;
using PracticeAPI.Models;

namespace PracticeAPI.Services;

public class UserService : IUserService
{
    private DaperContext _context;

    public UserService()
    {
        _context = new DaperContext();
    }

    public List<User> GetUsers()
    {
        var sql = @"select * from Users";
        var res = _context.GetConnection().Query<User>(sql).ToList();
        return res;
    }

    public User GetUserById(int userId)
    {
        var sql = @"select * from Users where UserId = @userId";
        var res = _context.GetConnection().Query<User>(sql, new { userId }).FirstOrDefault();
        return res;
    }

    public bool AddUser(User user)
    {
        return _context.GetConnection()
            .Execute(
                "Insert into User(UserId,FirstName,LastName,Email,UserName,Password) values (@UserId, @FirstName,@LastName,@Email,@UserName,@Password)",
                user) > 0;
    }

    public bool UpdateUser(User user)
    {
        return _context.GetConnection().Execute("Update User set FirstName=@FirstName,LastName=@LastName,Email=@Email,UserName=@UserName,Password=@Password  where Id=@Id", user) > 0;
    }

    public bool DeleteUser(int userId)
    {
        return _context.GetConnection().Execute("Delete User where Id = @Id", userId) > 0;  
    }
}