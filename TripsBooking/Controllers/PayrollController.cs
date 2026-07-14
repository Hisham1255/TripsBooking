using Microsoft.AspNetCore.Mvc;
using TripsBooking.Services;   // عدّل حسب فولدر Services عندك
using TripsBooking.DTOs;       // لو عندك DTOs
using Microsoft.AspNetCore.Authorization;

namespace TripsBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        // 👇 Get salary by employee id
        [Authorize]
        [HttpGet("my-salary")]
        public async Task<IActionResult> GetMySalary(
       [FromQuery] int year,
       [FromQuery] int month)
        {
            var empnClaim = User.FindFirst("EMPN")?.Value;

            if (empnClaim == null)
                return Unauthorized();

            int empn = int.Parse(empnClaim);

            var result = await _salaryService.GetSalaryByEmployeeId(empn, year, month);

            if (result == null)
                return NotFound("No salary data found");

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{empn}")]
        public async Task<IActionResult> GetSalaryByEmpn(int empn,[FromQuery] int year,[FromQuery] int month)
        {
            // نتأكد إن اللي داخل أدمن
            var roleClaim = User.FindFirst("Role")?.Value;

            if (roleClaim != "1")
                return Forbid();

            var result = await _salaryService.GetSalaryByEmployeeId(empn , year,month);

            if (result == null)
                return NotFound("No salary data found");

            return Ok(result);
        }


    }
}