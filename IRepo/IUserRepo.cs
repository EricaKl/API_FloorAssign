using API_FloorAssign.Models;

namespace API_FloorAssign.IRepo
{
    public interface IUserRepo
    {
        List<UserDetails> GetUsers(int id);
        bool AddUser(UserRegistration user);

        bool AddUserDetails(UserDetails user);

        int GetUserId(string email);
        bool UpdateUserDetails(UserDetails user, int id);

        bool DeleteUser(int id);

        List<UserDetails> GetProfileUser(string email);
        
    }
}
