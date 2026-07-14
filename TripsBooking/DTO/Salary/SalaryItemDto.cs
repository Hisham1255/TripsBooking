namespace TripsBooking.DTOs.Salary
{
    public class SalaryItemDto
    {
        public string Code { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Type { get; set; } = string.Empty; // earning / deduction
    }
}