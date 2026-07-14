namespace TripsBooking.DTOs.Auth
{
    public class ResetPasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}