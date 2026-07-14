using TripsBooking.DTO.Menha;
namespace TripsBooking.DTOs
{
    public class MenhaDto
    {
        public int? empn { get; set; }
        public string? Name { get; set; }
        public List<ItemDto> Earnings { get; set; }

        public List<ItemDto> Deductions { get; set; }

        public List<MenhaGroupedDeductionDto> GroupedDeductions { get; set; }

        public SummaryDto Summary { get; set; }
    }
}