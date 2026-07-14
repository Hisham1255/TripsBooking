using TripsBooking.Models;
using MenhaEntity = TripsBooking.Models.Menha;

namespace TripsBooking.Repositories.Menha
{
    public interface IMenhaRepository
    {
        Task<MenhaEntity?> GetByEmployeeIdAsync(int empn, int year, int month);
    }
}