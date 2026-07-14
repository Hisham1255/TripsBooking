namespace TripsBooking.DTO.Menha
{
    public class MenhaGroupedDeductionDto
    {
        public string Label { get; set; } = string.Empty;

        public List<MenhaGroupedDeductionItemDto> Items { get; set; } = new();
    }

    public class MenhaGroupedDeductionItemDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Value { get; set; }
    }
}