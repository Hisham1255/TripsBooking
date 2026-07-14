using System.ComponentModel.DataAnnotations;
    namespace TripsBooking.DTO.Trip
{
    public class AddTripDTO
    {
        [Required]
        public string Description { get; set; }
    }
}
