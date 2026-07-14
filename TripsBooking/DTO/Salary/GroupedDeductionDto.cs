namespace TripsBooking.DTOs.Salary
{
    public class GroupedDeductionDto
    {
        public string Label { get; set; } = string.Empty;
        public List<GroupedDeductionItemDto> Items { get; set; } = new();
    }

    public class GroupedDeductionItemDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}