using TripsBooking.Database;
using TripsBooking.DTOs.Salary;
using Microsoft.EntityFrameworkCore;

namespace TripsBooking.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepo;

        public SalaryService(ISalaryRepository salaryRepo)
        {
            _salaryRepo = salaryRepo;
        }

        // =========================
        // 💰 Earnings Labels
        // =========================
        private static readonly Dictionary<string, string> EarningsLabels = new()
        {
            { "DYWORK", "أيام عمل" },
            { "BSAL", "المرتب الأساسي" },
            { "INSOVER", "حافز جماعي" },
            { "NINC_ELAWA", "خاصه خ مرتب" },
            { "VEXPER", "حافز خبرة" },
            { "VSTAT", "إعانة اجتماعية" },
            { "PAUMAL", "عيد عمال" },
            { "PWORK", "طبيعة عمل" },
            { "PDL_TKRIR", "بدل تصنيع" },
            { "PDL_SPEC", "بدل مهني" },
            { "PTMSIL", "بدل تمثيل" },
            { "ELAWA_H_MUAHEL", "بدل دراسات عليا" },
            { "PDL_SMAA", "بدل سماعة" },
            { "OTHER_DEUS", "استحقاقات أخرى" },
            { "PDL_MKATR", "بدل مخاطر" },
            { "PDL_SPECIAL", "بدل تخصص" },
            { "PDL_MEAL", "بدل وجبة" },
            { "VPDL_ATLA", "بدل عطلة" },
            { "V_SEDBK", "علاوة غلاء 2023" },
            { "NWARDIA", "ورادى عدد" },
            { "PDL_WARDIA", "ورادى قيمة" },
            { "DEUS_MARADE_SAL", "استرداد مرضي ثابت" },
            { "DEUS_MARADE_VAR", "استرداد مرض متغير" },
            { "INS2019", "حافز قطعي" },
            { "T_V_RAMADAN", "تسوية رمضان" },
            { "Pincentive", "حافز إنتاج إضافي" },
            { "PDL_SICK", "بدل عدوي" },
            { "FARK_SOS", "تسوية" },
            { "TOTDEUS", "إجمالي الاستحقاقات" }
        };

        // =========================
        // 💸 Deductions Labels
        // =========================
        private static readonly Dictionary<string, string> DeductionsLabels = new()
        {
            { "SOS_SAL", "تأمينات مرتب" },
            { "VSUPPORT", "صندوق إعاقه" },
            { "NKABA_PETRO", "نقابة بترول" },
            { "VTKMELE", "معاش تكميلي" },
            { "VTAX", "ضرائب" },
            { "DED_PERIOD", "قسط مدة سابقة" },
            { "DED_SPORT", "لجنة رياضية واجتماعية" },
            { "SOS_SAL_MOSAHMA", "تأمينات علاج" },

            { "VDED82", "مكتبة الإسكندرية قسط" },
            { "BAL82", "مكتبة الإسكندرية رصيد" },

            { "VDED56", "معرض كتاب قسط" },
            { "BAL56", "معرض كتاب رصيد" },

            { "VYAM", "رحلات قسط" },
            { "BAL_YAM", "رحلات رصيد" },

            { "VDED70", "معرض حج وعمره قسط" },
            { "BAL70", "معرض حج وعمره رصيد" },

            { "VDED57", "دار المعارف قسط" },
            { "BAL57", "دار المعارف رصيد" },

            { "VDED53", "أدوية وعلاج أسر قسط" },
            { "BAL53", "أدوية وعلاج أسر رصيد" },

            { "VDED55", "أندية قسط" },
            { "BAL55", "أندية رصيد" },

            { "V_DED_53_PARK", "رحلات ترفيهية قسط" },
            { "BAL_DED_53_PARK", "رحلات ترفيهية رصيد" },

            { "V_MID", "رحلات نصف العام قسط" },
            { "BAL_MID", "رحلات نصف العام رصيد" },

            { "ded_alex", "سلف مدارس قسط" },
            { "TDED_ALEX", "سلف مدارس رصيد" },

            { "VDED60", "معرض بتروتريد قسط" },
            { "BAL60", "معرض بتروتريد رصيد" },

            { "BAL53_PARENT", "علاج والدين رصيد" },
            { "THARBI", "كرونا" },
            { "V_ALL_BANK", "قروض البنوك " },
            { "TEL_NET", "تليفونات محمولة" },
            { "VSICK_MSHMA", "مساهمة علاج أسر" },
            { "OTHER_DED", "أستقطاعات أخرى" },
            { "V_fathala", "بريميوم" },
            { "V_HEJ", "صندوق الشهيد" },
            { "DED_MARADE", "استقطاع مرضى" },
            { "V_57357", "تبرعات" },
            { "VAL_KAIR", "سهم الخير" },
            { "nowpay", "nowpay" },

            { "V_tay", " تاى هاوس قسط" },
            { "bal_tay", "تاى هاوس رصيد" },

            { "vtedata", "TEDATA" },

            { "V_HEJ_NEW", "رحلة العمره قسط" },
            { "BAL_HEJ_NEW", "رحلة العمره رصيد" },

            { "VDED83", "نقابة مهنية  قسط" },
            { "BAL83", "نقابة مهنية  رصيد" },

            { "FARK", "فروق" },

              { "VNEQABA", "كحك نقابة قسط" },
            { "BNEQABA", "كحك نقابة رصيد" },

              { "V_kest_takmeli", "تسوية م.تكميلى قسط" },
            { "T_kest_takmeli", "تسوية م.تكميلى رصيد" },

              { "VSOLAF", "سلفة رمضان قسط" },
            { "BAL_SOLAF", "سلفة رمضان رصيد" },

              { "V_KAHK", "سلفة كحك قسط" },
            { "BAL_KAHK", "سلفة كحك رصيد" },

            { "TOTDED", "اجمالى أستقطاعات" },

            { "NETSAL", "الصافى" }

        };

        public async Task<SalaryResponseDto> GetSalaryByEmployeeId(int employeeId, int year, int month)
        {
            var employee = await _salaryRepo.GetByEmployeeId(employeeId, year, month);

            if (employee == null)
                return new SalaryResponseDto();

            decimal ToDecimal(object? value)
            {
                if (value == null)
                    return 0m;

                return Convert.ToDecimal(value);
            }

            // =========================
            // 💰 Earnings
            // =========================
            var earnings = new List<SalaryItemDto>
            {
                new() { Code = "BSAL", Label = GetArabicLabel("BSAL"), Value = ToDecimal(employee.BSAL) },
                new() { Code = "DYWORK", Label = GetArabicLabel("DYWORK"), Value = ToDecimal(employee.DYWORK) },
                new() { Code = "INSOVER", Label = GetArabicLabel("INSOVER"), Value = ToDecimal(employee.INSOVER) },
                new() { Code = "NINC_ELAWA", Label = GetArabicLabel("NINC_ELAWA"), Value = ToDecimal(employee.NINC_ELAWA) },
                new() { Code = "VEXPER", Label = GetArabicLabel("VEXPER"), Value = ToDecimal(employee.VEXPER) },
                new() { Code = "VSTAT", Label = GetArabicLabel("VSTAT"), Value = ToDecimal(employee.VSTAT) },
                new() { Code = "PAUMAL", Label = GetArabicLabel("PAUMAL"), Value = ToDecimal(employee.PAUMAL) },
                new() { Code = "PWORK", Label = GetArabicLabel("PWORK"), Value = ToDecimal(employee.PWORK) },

                new() { Code = "PDL_TKRIR", Label = GetArabicLabel("PDL_TKRIR"), Value = ToDecimal(employee.PDL_TKRIR) },
                new() { Code = "PDL_SPEC", Label = GetArabicLabel("PDL_SPEC"), Value = ToDecimal(employee.PDL_SPEC) },
                new() { Code = "PTMSIL", Label = GetArabicLabel("PTMSIL"), Value = ToDecimal(employee.PTMSIL) },
                new() { Code = "ELAWA_H_MUAHEL", Label = GetArabicLabel("ELAWA_H_MUAHEL"), Value = ToDecimal(employee.ELAWA_H_MUAHEL) },
                new() { Code = "PDL_SMAA", Label = GetArabicLabel("PDL_SMAA"), Value = ToDecimal(employee.PDL_SMAA) },
                new() { Code = "OTHER_DEUS", Label = GetArabicLabel("OTHER_DEUS"), Value = ToDecimal(employee.OTHER_DEUS) },
                new() { Code = "PDL_MKATR", Label = GetArabicLabel("PDL_MKATR"), Value = ToDecimal(employee.PDL_MKATR) },
                new() { Code = "PDL_SPECIAL", Label = GetArabicLabel("PDL_SPECIAL"), Value = ToDecimal(employee.PDL_SPECIAL) },

                new() { Code = "PDL_MEAL", Label = GetArabicLabel("PDL_MEAL"), Value = ToDecimal(employee.PDL_MEAL) },
                new() { Code = "VPDL_ATLA", Label = GetArabicLabel("VPDL_ATLA"), Value = ToDecimal(employee.VPDL_ATLA) },
                new() { Code = "PDL_SICK", Label = GetArabicLabel("PDL_SICK"), Value = ToDecimal(employee.PDL_SICK) },
                new() { Code = "FARK_SOS", Label = GetArabicLabel("FARK_SOS"), Value = ToDecimal(employee.FARK_SOS) },
                new() { Code = "V_SEDBK", Label = GetArabicLabel("V_SEDBK"), Value = ToDecimal(employee.V_SEDBK) },
                new() { Code = "NWARDIA", Label = GetArabicLabel("NWARDIA"), Value = ToDecimal(employee.NWARDIA) },
                new() { Code = "PDL_WARDIA", Label = GetArabicLabel("PDL_WARDIA"), Value = ToDecimal(employee.PDL_WARDIA) },
                new() { Code = "DEUS_MARADE_SAL", Label = GetArabicLabel("DEUS_MARADE_SAL"), Value = ToDecimal(employee.DEUS_MARADE_SAL) },

                new() { Code = "DEUS_MARADE_VAR", Label = GetArabicLabel("DEUS_MARADE_VAR"), Value = ToDecimal(employee.DEUS_MARADE_VAR) },
                new() { Code = "INS2019", Label = GetArabicLabel("INS2019"), Value = ToDecimal(employee.INS2019) },
                new() { Code = "T_V_RAMADAN", Label = GetArabicLabel("T_V_RAMADAN"), Value = ToDecimal(employee.T_V_RAMADAN) },
                new() { Code = "Pincentive", Label = GetArabicLabel("Pincentive"), Value = ToDecimal(employee.Pincentive) },
                
            };

            // =========================
            // 💸 Deductions (العادية فقط)
            // =========================
            var deductions = new List<SalaryItemDto>
            {
                new()
                {
                    Code = "SOS_SAL",
                    Label = GetDeductionLabel("SOS_SAL"),
                    Value = ToDecimal(employee.SOS_SAL)
                },

                new()
                {
                    Code = "VSUPPORT",
                    Label = GetDeductionLabel("VSUPPORT"),
                    Value = ToDecimal(employee.VSUPPORT)
                },

                new()
                {
                    Code = "NKABA_PETRO",
                    Label = GetDeductionLabel("NKABA_PETRO"),
                    Value = ToDecimal(employee.NKABA_PETRO)
                },

                new()
                {
                    Code = "VTKMELE",
                    Label = GetDeductionLabel("VTKMELE"),
                    Value = ToDecimal(employee.VTKMELE)
                },

                new()
                {
                    Code = "VTAX",
                    Label = GetDeductionLabel("VTAX"),
                    Value = ToDecimal(employee.VTAX)
                },

                new()
                {
                    Code = "DED_PERIOD",
                    Label = GetDeductionLabel("DED_PERIOD"),
                    Value = ToDecimal(employee.DED_PERIOD)
                },

                new()
                {
                    Code = "DED_SPORT",
                    Label = GetDeductionLabel("DED_SPORT"),
                    Value = ToDecimal(employee.DED_SPORT)
                },

                new()
                {
                    Code = "SOS_SAL_MOSAHMA",
                    Label = GetDeductionLabel("SOS_SAL_MOSAHMA"),
                    Value = ToDecimal(employee.SOS_SAL_MOSAHMA)
                },


               
                new()
                {
                    Code = "BAL53_PARENT",
                    Label = GetDeductionLabel("BAL53_PARENT"),
                    Value = ToDecimal(employee.BAL53_PARENT)
                },

                new()
                {
                    Code = "THARBI",
                    Label = GetDeductionLabel("THARBI"),
                    Value = ToDecimal(employee.THARBI)
                },

                new()
                {
                    Code = "V_ALL_BANK",
                    Label = GetDeductionLabel("V_ALL_BANK"),
                    Value = ToDecimal(employee.V_ALL_BANK)
                },

                new()
                {
                    Code = "TEL_NET",
                    Label = GetDeductionLabel("TEL_NET"),
                    Value = ToDecimal(employee.TEL_NET)
                },

                new()
                {
                    Code = "VSICK_MSHMA",
                    Label = GetDeductionLabel("VSICK_MSHMA"),
                    Value = ToDecimal(employee.VSICK_MSHMA)
                },

                new()
                {
                    Code = "OTHER_DED",
                    Label = GetDeductionLabel("OTHER_DED"),
                    Value = ToDecimal(employee.OTHER_DED)
                },

                new()
                {
                    Code = "V_fathala",
                    Label = GetDeductionLabel("V_fathala"),
                    Value = ToDecimal(employee.V_fathala)
                },

                new()
                {
                    Code = "V_HEJ",
                    Label = GetDeductionLabel("V_HEJ"),
                    Value = ToDecimal(employee.V_HEJ)
                },

                new()
                {
                    Code = "DED_MARADE",
                    Label = GetDeductionLabel("DED_MARADE"),
                    Value = ToDecimal(employee.DED_MARADE)
                },

                new()
                {
                    Code = "V_57357",
                    Label = GetDeductionLabel("V_57357"),
                    Value = ToDecimal(employee.V_57357)
                },

               
                new()
                {
                    Code = "VAL_KAIR",
                    Label = GetDeductionLabel("VAL_KAIR"),
                    Value = ToDecimal(employee.VAL_KAIR)
                },

                new()
                {
                    Code = "nowpay",
                    Label = GetDeductionLabel("nowpay"),
                    Value = ToDecimal(employee.nowpay)
                },

                new()
                {
                    Code = "vtedata",
                    Label = GetDeductionLabel("vtedata"),
                    Value = ToDecimal(employee.vtedata)
                },

                new()
                {
                    Code = "FARK",
                    Label = GetDeductionLabel("FARK"),
                    Value = ToDecimal(employee.FARK)
                }

            
            };

            // =========================
            // 📦 Grouped Deductions
            // =========================
            var groupedDeductions = new List<GroupedDeductionDto>
            {
                CreateGroup("مكتبة الإسكندرية", employee.VDED82, employee.BAL82),
                CreateGroup("معرض الكتاب", employee.VDED56, employee.BAL56),
                CreateGroup("رحلات", employee.VYAM, employee.BAL_YAM),
                CreateGroup("حج وعمرة", employee.VDED70, employee.BAL70),
                CreateGroup("دار المعارف", employee.VDED57, employee.BAL57),
                CreateGroup("أدوية وعلاج أسر", employee.VDED53, employee.BAL53),
                CreateGroup("أندية", employee.VDED55, employee.BAL55),
                CreateGroup("رحلات ترفيهية", employee.V_DED_53_PARK, employee.BAL_DED_53_PARK),
                CreateGroup("رحلات نصف العام", employee.V_MID, employee.BAL_MID),
                CreateGroup("سلف مدارس", employee.ded_alex, employee.TDED_ALEX),
                CreateGroup("معرض بتروتريد", employee.VDED60, employee.BAL60),
                CreateGroup("تاى هاوس", employee.V_tay, employee.bal_tay),
                CreateGroup("رحلة العمره", employee.V_HEJ_NEW, employee.BAL_HEJ_NEW),
                CreateGroup("نقابة مهنية ", employee.VDED83, employee.BAL83),
                CreateGroup("كحك نقابة", employee.VNEQABA, employee.BNEQABA),
                CreateGroup("تسوية م.تكميلى", employee.V_kest_takmeli, employee.T_kest_takmeli),
                CreateGroup("سلفة رمضان", employee.VSOLAF, employee.BAL_SOLAF),
                CreateGroup("سلفة كحك", employee.V_KAHK, employee.BAL_KAHK)
            };

            // =========================
            // 💰 Totals
            // =========================
            var totalEarnings = earnings.Sum(x => x.Value);

            var totalDeductions =
                deductions.Sum(x => x.Value)
                + groupedDeductions.Sum(g => g.Items.Sum(i => i.Value));

            return new SalaryResponseDto
            {
                Empn = (int)employee.EmployeeId,
                Name = employee.Name,
                Sanawi = employee.sanawi,
                Arda = employee.arda,
                Maradi = employee.maradi,

                Earnings = earnings,
                Deductions = deductions,
                GroupedDeductions = groupedDeductions,

                Summary = new SalarySummaryDto
                {
                    TotalEarnings = ToDecimal(employee.TOTDEUS),
                    TotalDeductions = ToDecimal(employee.TOTDED),
                    NetSalary = ToDecimal(employee.NETSAL),                 
                }
            };
        }

        // =========================
        // 📦 Helper Method
        // =========================
        private GroupedDeductionDto CreateGroup(
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

            return new GroupedDeductionDto
            {
                Label = label,

                Items = new List<GroupedDeductionItemDto>
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

        private string GetArabicLabel(string code)
            => EarningsLabels.TryGetValue(code, out var label)
                ? label
                : code;

        private string GetDeductionLabel(string code)
            => DeductionsLabels.TryGetValue(code, out var label)
                ? label
                : code;
    }
}