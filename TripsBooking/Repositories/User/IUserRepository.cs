using TripsBooking.Models;
using UserEntity = TripsBooking.Models.User;

namespace TripsBooking.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByUsername(string username);
        Task<UserEntity?> GetById(int id);
        Task Add(UserEntity user);
    }
}