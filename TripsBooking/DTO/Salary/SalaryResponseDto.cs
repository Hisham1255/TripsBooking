using System.Collections.Generic;

namespace TripsBooking.DTOs.Salary
{
    public class SalaryResponseDto
    {
        public int Empn { get; set; }
        public string? Name { get; set; }
        public double? Sanawi { get; set; }
        public double? Arda { get; set; }
        public double? Maradi { get; set; }
        public List<SalaryItemDto> Earnings { get; set; } = new();

        public List<SalaryItemDto> Deductions { get; set; } = new();

        public List<GroupedDeductionDto> GroupedDeductions { get; set; } = new();

        // 📊 Summary
        public SalarySummaryDto Summary { get; set; } = new();
    }
}