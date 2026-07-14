using TripsBooking.Models;

public interface ISalaryRepository
{
    Task<SalaryItem?> GetByEmployeeId(int employeeId, int year, int month);
}