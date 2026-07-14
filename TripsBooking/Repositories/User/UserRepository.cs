using Microsoft.EntityFrameworkCore;
using TripsBooking.Database;
using TripsBooking.Models;
using UserEntity = TripsBooking.Models.User;

namespace TripsBooking.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByUsername(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserEntity?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Add(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}