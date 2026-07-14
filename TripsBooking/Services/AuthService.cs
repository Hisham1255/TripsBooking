using Microsoft.EntityFrameworkCore;
using TripsBooking.Database;
using TripsBooking.DTOs.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using TripsBooking.Repositories.User;

namespace TripsBooking.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;


        public AuthService(IUserRepository userRepo, IConfiguration config)
        {

            _userRepo = userRepo;
            _config = config;
        }
        public async Task<(string? Token, int? Empn, int? Role)> Login(LoginDto dto)
        {
            var user = await _userRepo.GetByUsername(dto.Username);

            if (user == null)
                return (null, null, null);

            var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!isValid)
                return (null, null, null);


            var claims = new[]
{
    new Claim(ClaimTypes.Name, user.Username),
    new Claim("UserId", user.Id.ToString()),
    new Claim("EMPN", user.EMPN.ToString()),
    new Claim("Role", user.Role.ToString())
};



            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return (jwt, user.EMPN, user.Role);
        }
    }
}