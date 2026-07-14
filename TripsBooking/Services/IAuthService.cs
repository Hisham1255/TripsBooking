using TripsBooking.DTOs.Auth;

namespace TripsBooking.Services
{
    public interface IAuthService
    {
        Task<(string? Token, int? Empn, int? Role)> Login(LoginDto dto);
    }
}