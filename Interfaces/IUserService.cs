using PracticeAPI.Models;

namespace PracticeAPI.Interfaces;

public interface IUserService
{
     List<User> GetUsers();
     User GetUserById(int userId);
     bool AddUser(User user);
     bool UpdateUser(User user);
     bool DeleteUser(int userId);  
}