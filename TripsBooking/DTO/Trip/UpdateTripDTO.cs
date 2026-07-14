using System.ComponentModel.DataAnnotations;
namespace TripsBooking.DTO.Trip
{
    public class UpdateTripDTO
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
