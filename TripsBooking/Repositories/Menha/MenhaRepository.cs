using Microsoft.EntityFrameworkCore;
using TripsBooking.Database;
using TripsBooking.Models;
using MenhaEntity = TripsBooking.Models.Menha;

namespace TripsBooking.Repositories.Menha
{
    public class MenhaRepository : IMenhaRepository
    {
        private readonly AppDbContext _context;

        public MenhaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MenhaEntity?> GetByEmployeeIdAsync(int empn , int year,int month)
        {
            return await _context.Menha.FirstOrDefaultAsync(x =>
         x.EmployeeId == empn &&
         x.MenhaYear == year &&
         x.MenhaMonth == month);
        }
    }
}