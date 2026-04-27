using server.models;

namespace server.services
{
    public interface IUserService
    {
        Task<User?> createUser(User user);
        Task<IEnumerable<User>> getAllUsers();
        Task<User> login(string userName, string password);
    }
}