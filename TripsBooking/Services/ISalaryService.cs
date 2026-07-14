using TripsBooking.DTOs.Salary;

namespace TripsBooking.Services
{
    public interface ISalaryService
    {
        Task<SalaryResponseDto> GetSalaryByEmployeeId(int employeeId, int year, int month);
    }
}