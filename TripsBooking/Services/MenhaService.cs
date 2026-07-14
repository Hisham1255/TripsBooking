using TripsBooking.DTOs;
using TripsBooking.DTO.Menha;
using TripsBooking.Repositories.Menha;

namespace TripsBooking.Services
{
    public class MenhaService
    {
        private readonly IMenhaRepository _repo;

        public MenhaService(IMenhaRepository repo)
        {
            _repo = repo;
        }

        public async Task<MenhaDto> GetMyMenhaAsync(int empn, int year, int month)
        {
            var menha = await _repo.GetByEmployeeIdAsync(empn, year, month);

            if (menha == null)
                return null;

            var earnings = new List<ItemDto>
{
    new ItemDto("أيام عمل", (decimal?)menha.IN_DAYS_ANRPC ?? 0),
    new ItemDto("مرتب المنحة", (decimal?)menha.SAL_ANRPC ?? 0),
    new ItemDto("قيمة المنحة", (decimal?)menha.VAL_MENHA_ANRPC ?? 0),
    new ItemDto("100% من المنحة", (decimal?)menha.VAL_MENHA_HALF_ANRPC ?? 0),
    new ItemDto("استحقاقات أخرى", (decimal?)menha.OTHER_deus ?? 0),
    new ItemDto("إضافي", (decimal?)menha.EDAFI_VAL ?? 0),
    new ItemDto("تسوية ترقية", (decimal?)menha.VFS ?? 0),
};
            var deductions = new List<ItemDto>
{
   
    new ItemDto("مساهمة علاج أسر ", (decimal?)menha.VSICK ?? 0),
    new ItemDto("سهم الخير", (decimal?)menha.VAL_KAIR ?? 0),
    new ItemDto("معــاش تكمـيلى", (decimal?)menha.VTKMELE ?? 0),
    new ItemDto("أستقطاعات أخـرى", (decimal?)menha.OTHER_ded ?? 0),
    new ItemDto("فـــــــروق", (decimal?)menha.FARK ?? 0),
             
};


            var groupedDeductions = new List<MenhaGroupedDeductionDto>
{
    CreateGroup("علاج", menha.VAL_DED_SICK, menha.bal_VAL_DED_SICK),
    CreateGroup("كرونا", menha.V_HARBI, menha.TOT_HARBI),
    CreateGroup("حج وعمرة", menha.VHEG, menha.VHEG_BAL),
    CreateGroup("سلفة مدارس", menha.V_MOAMERA, menha.T_MOAMERA),
    CreateGroup("رحلات", menha.VAL_DED_trip, menha.BAL_DED_trip),
    CreateGroup("رحلات ترفيهية", menha.V_DED_53_PARK, menha.BAL_DED_53_PARK),
    CreateGroup("نصف عام", menha.V_MID, menha.BAL_MID),
    CreateGroup("كحك العيد", menha.V_KAHK, menha.TOT_KAHK),
    CreateGroup("سلفة رمضان", menha.VAL_DED_SOLAF, menha.BAL_DED_SOLAF)
};


            return new MenhaDto
            {
                empn = menha.EmployeeId,
                Name = menha.ENAME,   // 👈 ده أهم سطر
                Earnings = earnings,
                Deductions = deductions,
                GroupedDeductions = groupedDeductions,

                Summary = new SummaryDto
                {
                    TotalEarnings = (decimal)(menha.TOT_DEUS ?? 0),
                    TotalDeductions = (decimal)(menha.TOT_DED ?? 0),
                    NetSalary = (decimal)(menha.NET_MENHA ?? 0)
                }
            };
        }

        //Helper
        private MenhaGroupedDeductionDto CreateGroup(
    string label,
    object? installment,
    object? balance)
        {
            decimal ToDecimal(object? value)
            {
                if (value == null)
                    return 0m;

                return Convert.ToDecimal(value);
            }

            return new MenhaGroupedDeductionDto
            {
                Label = label,

                Items = new List<MenhaGroupedDeductionItemDto>
        {
            new()
            {
                Name = "قسط",
                Value = ToDecimal(installment)
            },
            new()
            {
                Name = "رصيد",
                Value = ToDecimal(balance)
            }
        }
            };
        }
    }
}