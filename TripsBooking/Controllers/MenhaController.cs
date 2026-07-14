using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripsBooking.Services;

namespace TripsBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenhaController : ControllerBase
    {
        private readonly MenhaService _service;

        public MenhaController(MenhaService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("my-menha")]
        public async Task<IActionResult> GetMyMenha(
            [FromQuery] int year,
            [FromQuery] int month)
        {
            var empnClaim = User.Claims
                .FirstOrDefault(c => c.Type == "EMPN")?.Value;

            if (!int.TryParse(empnClaim, out var empn))
                return Unauthorized();

            var result = await _service.GetMyMenhaAsync(empn, year, month);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{empn}")]
        public async Task<IActionResult> GetMenhaByEmpn(
         int empn,
         [FromQuery] int year,
         [FromQuery] int month)
        {
            var roleClaim = User.FindFirst("Role")?.Value;

            if (roleClaim != "1")
                return Forbid();

            var result = await _service.GetMyMenhaAsync(empn, year, month);

            if (result == null)
                return NotFound("No menha data found");

            return Ok(result);
        }

    }
}