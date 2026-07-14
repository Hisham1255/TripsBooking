using Microsoft.EntityFrameworkCore;
using TripsBooking.Database;
using TripsBooking.Models;
using TripsBooking.Repositories; // أو المكان الصح بتاع الـ interface

public class SalaryRepository : ISalaryRepository
{
    private readonly AppDbContext _context;

    public SalaryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SalaryItem?> GetByEmployeeId(int employeeId, int year, int month)
    {
        return await _context.SalaryItems.FirstOrDefaultAsync(x =>
        x.EmployeeId == employeeId &&
        x.SalaryYear == year &&
        x.SalaryMonth == month);
    }
}