using Microsoft.EntityFrameworkCore;
using server.models;

namespace server.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChineseSaleDbContext _context;
        public UserRepository(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> getAllUsers()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> createUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return _context.User.FirstOrDefault(user);
        }
    }
}
