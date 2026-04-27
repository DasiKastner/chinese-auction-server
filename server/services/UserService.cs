using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.models;
using server.repositories;

namespace server.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly ChineseSaleDbContext _context;
        public UserService(IUserRepository userRepository, ChineseSaleDbContext context)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
            _context = context;
        }
        public async Task<IEnumerable<User>> getAllUsers()
        {
            try
            {
                return await _userRepository.getAllUsers();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<User?> createUser(User user)
        {
            try
            {
                User? UniqueUser = _context.User.FirstOrDefault(u => u.UserName == user.UserName);
                if (UniqueUser == null)
                {
                    user.Password = _passwordHasher.HashPassword(user, user.Password);
                    user.Role = "user";
                    return await _userRepository.createUser(user);
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<User?> login(string userName, string password)
        {
            try
            {
                Console.WriteLine("mmmeeeee");
                IEnumerable<User> users = await _userRepository.getAllUsers();
                User? user = users.FirstOrDefault(u => u.UserName == userName);
                if (user != null)
                {
                    Console.WriteLine("gfgfgfgfgfgfgf");
                    var s = _passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success;
                    if (s == false)
                        return null;
                    else
                        return user;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
