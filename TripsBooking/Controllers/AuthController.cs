using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TripsBooking.Database;
using TripsBooking.DTOs.Auth;
using TripsBooking.Models;
using TripsBooking.Services;

namespace TripsBooking.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [Authorize]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var userId = User.FindFirst("UserId")?.Value;

            if (userId == null)
                return Unauthorized();

            var user = await _context.Users.FindAsync(int.Parse(userId));

            if (user == null)
                return NotFound();

            var isValid = BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.Password);

            if (!isValid)
                return BadRequest("Current password is incorrect");

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            await _context.SaveChangesAsync();

            return Ok("Password updated successfully");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == dto.Username);

            if (existingUser != null)
                return BadRequest("Username already exists");

            var user = new User
            {
                Username = dto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                EMPN = dto.EMPN
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User created successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);

            if (result.Token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new
            {
                token = result.Token,
                empn = result.Empn,
                role = result.Role
            });
        }
    }
}