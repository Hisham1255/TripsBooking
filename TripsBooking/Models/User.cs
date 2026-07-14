using System.ComponentModel.DataAnnotations;

namespace TripsBooking.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int EMPN { get; set; }

        public int Role { get; set; }   // 0 User - 1 Admin
    }
}