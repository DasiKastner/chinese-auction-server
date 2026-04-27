using server.models;

namespace server.repositories
{
    public interface IUserRepository
    {
        Task<User> createUser(User user);
        Task<IEnumerable<User>> getAllUsers();
    }
}